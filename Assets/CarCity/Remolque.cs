using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remolque : GAgent
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        SubGoal S1 = new SubGoal("isWaitingForCars", 1, false);
        goals.Add(S1, 3);
    }
}
