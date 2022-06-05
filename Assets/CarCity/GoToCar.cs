using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToCar : GAction
{
    //private GameObject brokenCar;
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveBrokenCar();

        if (target == null)
            return false;
        //brokenCar = target;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("carOutOfGas", -1);
        target.GetComponent<Coche>().beliefs.ModifyState("gruaHaVenido", 1);
        target.GetComponent<NavMeshAgent>().isStopped = false;
        return true;
    }

    
}
