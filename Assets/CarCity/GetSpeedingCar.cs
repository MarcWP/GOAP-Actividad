using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeedingCar : GAction
{
    //private GameObject brokenCar;
    GameObject resource;

    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveSpeedingCar();
        if (target == null)
        {
            return false;
        }
        Debug.Log("Spe: " + target);   

        resource = GWorld.Instance.RemovePrison();
        if (resource != null)
            inventory.AddItem(resource);
        else
        {
            GWorld.Instance.AddSpeedingCar(target);
            target = null;
            return false;
        }
        Debug.Log("pris: " + resource);   

        GWorld.Instance.GetWorld().ModifyState("freePrison", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("speedingCar", -1);
        
        target.GetComponent<Coche>().beliefs.ModifyState("policeHasCome", 1);
        target.GetComponent<GAgent>().inventory.AddItem(resource);
        
        return true;
    }
}