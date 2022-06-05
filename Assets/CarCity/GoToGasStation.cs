using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToGasStation : GAction
{
    private Coche _coche;

    private void Start()
    {
        _coche = gameObject.GetComponent<Coche>();
    }
    
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("emptyTank");
        beliefs.ModifyState("filledTank", 1);
        beliefs.RemoveState("gruaHaVenido");
        _coche._gas = Random.Range( _coche._maxGas / 2,  _coche._maxGas);
        return true;
    }
}
