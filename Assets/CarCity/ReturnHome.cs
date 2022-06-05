using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnHome : GAction
{
    public override bool PrePerform()
    {
        if (transform.GetComponent<Coche>()._gas <= 0 || beliefs.HasState("speeding"))
        {
            return false;
        }

        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
