using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSpeederToPrison : GAction
{

    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Prison");
        if (target == null)
            return false;

        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("jailingSpeeder", 1);
        GWorld.Instance.AddPrison(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("freePrison", 1);
        return true;
    }
}
