using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWork : GAction
{
    private Upgrades _upgrades;
    public float _moneyDelta;

    private void Start()
    {
        _upgrades = FindObjectOfType<Upgrades>();
    }

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
        _upgrades.UpdateTotalBalance(_moneyDelta);
        return true;
    }
}
