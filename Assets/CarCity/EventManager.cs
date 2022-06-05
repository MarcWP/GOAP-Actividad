using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }
    
    public event Action<float> onIncreaseGas;
    
    public void IncreaseGas(float gasMultiplier)
    {
        onIncreaseGas?.Invoke(gasMultiplier);
    }
    
    public event Action<float> onIncreasePatience;
    
    public void IncreasePatience(float patienceMultiplier)
    {
        onIncreasePatience?.Invoke(patienceMultiplier);
    }
}