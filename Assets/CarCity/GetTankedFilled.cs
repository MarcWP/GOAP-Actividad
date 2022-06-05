using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetTankedFilled : GAction
{
    private Coche _coche;
    private NavMeshAgent _navMeshAgent;
    
    private void Start()
    {
        _coche = gameObject.GetComponent<Coche>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.ModifyState("filledTank", 0);
        beliefs.RemoveState("emptyTank");
        _coche._gas = 10;
        
        return true;
    }
}
