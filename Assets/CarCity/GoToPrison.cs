using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPrison : GAction
{
    private Coche _coche;

    private void Start()
    {
        _coche = gameObject.GetComponent<Coche>();
    }
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Prison");
        if (target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Detained", 1);
        beliefs.RemoveState("speeding");
        beliefs.RemoveState("policeHasCome");
        //beliefs.ModifyState("isFree", 1);
        inventory.RemoveItem(target);
        _coche._patience = Random.Range( _coche._maxPatience / 2,  _coche._maxPatience);
        _coche._navMeshAgent.speed = _coche._regularSpeed;
        return true;
    }
}