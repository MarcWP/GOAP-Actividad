using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Coche : GAgent
{
    public float _gas;
    private bool _outOfGas;
    public float _maxGas;
    
    public float _patience;
    public float _maxPatience;
    private bool _speeding;

    [SerializeField] public float _speedingSpeed;
    public float _regularSpeed;
    public NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        base.Start();
        SubGoal S1 = new SubGoal("goHome", 1, false);
        goals.Add(S1, 1);
        SubGoal S2 = new SubGoal("isFilled", 1, false);
        goals.Add(S2, 3);
        SubGoal s3 = new SubGoal("isFree", 1, false);
        goals.Add(s3, 5);
        
        _gas = Random.Range(_maxGas/2, _maxGas);
        _patience = Random.Range(_maxPatience/2, _maxPatience);
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _regularSpeed = _navMeshAgent.speed;
        
        beliefs.ModifyState("filledTank", 1);
        beliefs.ModifyState("atHome", 1);

        EventManager.current.onIncreaseGas += IncreaseGas;
        EventManager.current.onIncreasePatience += IncreasePatience;
    }

    private void FixedUpdate()
    {
        CheckGas();
        CheckPatience();
    }

    private void CheckPatience()
    {
        if (_patience > 0)
        {
            _patience -= Time.deltaTime;
            if (_speeding)
            {
                _speeding = false;
            }

            if (_navMeshAgent.speed == _speedingSpeed)
            {
                _speedingSpeed = _regularSpeed;
            }
        }

        if (_patience <= 0 && !_speeding && !beliefs.HasState("emptyTank"))
        {
            float randomChance = Random.Range(0, 10);
            if (randomChance < 5)
            {
                //beliefs.RemoveState("filledTank");
                _navMeshAgent.speed = _speedingSpeed;
                beliefs.ModifyState("speeding", 1);
                GWorld.Instance.GetWorld().ModifyState("speedingCar", 1);
                GWorld.Instance.AddSpeedingCar(gameObject);
                _speeding = true;
            }
            else
            {
                _patience = Random.Range(_maxPatience / 2, _maxPatience);
            }
        }
    }

    private void CheckGas()
    {
        if (_gas > 0 && !beliefs.HasState("speeding"))
        {
            _gas -= Time.deltaTime;
            if (_outOfGas)
            {
                _outOfGas = false;
            }
        }

        if (_gas <= 0 && !_outOfGas)
        {
            beliefs.RemoveState("filledTank");
            beliefs.ModifyState("emptyTank", 1);
            GWorld.Instance.GetWorld().ModifyState("carOutOfGas", 1);
            GWorld.Instance.AddBrokenCar(gameObject);
            _outOfGas = true;
        }
    }

    void IncreaseGas(float multiplier)
    {
        _maxGas *= multiplier;
    }
    
    void IncreasePatience(float multiplier)
    {
        _maxPatience *= multiplier;
    }
}
