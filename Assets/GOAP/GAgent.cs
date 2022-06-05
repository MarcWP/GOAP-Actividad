﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SubGoal
{
    public Dictionary<string, int> sgoals;
    public bool remove;

    public SubGoal(string s, int i, bool r)
    {
        sgoals = new Dictionary<string, int>();
        sgoals.Add(s, i);
        remove = r;
    }
}

public class GAgent : MonoBehaviour
{
    public List<GAction> actions = new List<GAction>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
    public WorldStates beliefs = new WorldStates();
    public GInventory inventory = new GInventory();

    GPlanner planner;
    Queue<GAction> actionQueue;
    public GAction currentAction;
    SubGoal currentGoal;

    // Start is called before the first frame update
    public void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();
        foreach (GAction a in acts)
            actions.Add(a);
    }


    bool invoked = false;
    void CompleteAction()
    {
        currentAction.running = false;
        currentAction.PostPerform();
        invoked = false;
    }
    
    void AbortAction()
    {
        currentAction.running = false;
    }

    void LateUpdate()
    {
        if (currentAction != null && currentAction.running)
        {
            // si el navmesh no está calculando bien el remaining distance, se puede
            //calcular la distancia a mano.
            
            //print("Isaction: "+ currentAction+"AchievableGiven: " + currentAction.IsAchievableGiven(currentAction.beliefs.states) + "pre: " + currentAction.preconditions.Values.First());
            // if (!currentAction.IsAchievableGiven(currentAction.beliefs.GetStates()))
            // {
            //     print(currentAction.actionName + " not achievable, aborting");
            //     AbortAction();
            //     return;
            // }
            float distanceToTarget = Vector3.Distance(currentAction.target.transform.position, this.transform.position);
            //if (currentAction.agent.hasPath && distanceToTarget < 2f) //currentAction.agent.remainingDistance < 2f)
            if (distanceToTarget < 2f) 
            {
                if (!invoked)
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            else
            {
                if ((currentAction.actionName == "GoToWork" || currentAction.actionName == "Return Home"))
                {
                    if (currentAction.gameObject.GetComponent<Coche>()._gas <= 0)
                    {
                        AbortAction();
                        currentAction.agent.isStopped = true;
                    }

                    if (currentAction.gameObject.GetComponent<Coche>().beliefs.HasState("policeHasCome"))
                    {
                        AbortAction();
                    }
                }
                
                    
                    
                // si navmesh agent tiene goal pero la distancia ealobjetivo mayor que 2 -> estoy en tránsito
                // si estoy en transito tengo que comprobar que hay gas
                // la lógica cuando termina la acción
                // AbortAction();
                //parar navmeshagent
                //en los preperform poner si no hay gas return false.
            }

            if (currentAction.followTarget)
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);

                if (currentAction.target != null)
                {
                    currentAction.running = true;
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            return;
        }

        if (planner == null || actionQueue == null)
        {
            planner = new GPlanner();

            var sortedGoals = from entry in goals orderby entry.Value descending select entry;

            foreach (KeyValuePair<SubGoal, int> sg in sortedGoals)
            {
                actionQueue = planner.plan(actions, sg.Key.sgoals, beliefs);
                if (actionQueue != null)
                {
                    currentGoal = sg.Key;
                    break;
                }
            }
        }

        if (actionQueue != null && actionQueue.Count == 0)
        {
            if (currentGoal.remove)
            {
                goals.Remove(currentGoal);
            }
            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0)
        {
            currentAction = actionQueue.Dequeue();
            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);

                if (currentAction.target != null)
                {
                    currentAction.running = true;
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            else
            {
                actionQueue = null;
            }

        }

    }
}
