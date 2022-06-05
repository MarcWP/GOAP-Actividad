using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static Queue<GameObject> prisons;
    private static Queue<GameObject> brokenCars;
    private static Queue<GameObject> speedingCars;


    static GWorld()
    {
        world = new WorldStates();
        prisons = new Queue<GameObject>();
        brokenCars = new Queue<GameObject>();
        speedingCars = new Queue<GameObject>();
        
        
        GameObject[] cells = GameObject.FindGameObjectsWithTag("Prison");
        foreach (GameObject o in cells)
            prisons.Enqueue(o);
        if (cells.Length > 0)
            world.ModifyState("freePrison", cells.Length);
        
        

        /*GameObject[] puds = GameObject.FindGameObjectsWithTag("Puddle");
        foreach (GameObject p in puds)
            puddles.Enqueue(p);
        if (puds.Length > 0)
            world.ModifyState("uncleanPuddle", puds.Length);*/

        Time.timeScale = 5;

    }

    private GWorld()
    {
    }
    
    
    public void AddPrison(GameObject p)
    {
        prisons.Enqueue(p);
    }
    public GameObject RemovePrison()
    {
        if (prisons.Count == 0) return null;
        return prisons.Dequeue();
    }

    public void AddBrokenCar(GameObject p)
    {
        brokenCars.Enqueue(p);
    }
    
    public GameObject RemoveBrokenCar()
    {
        if (brokenCars.Count == 0) return null;
        return brokenCars.Dequeue();
    }
    
    public void AddSpeedingCar(GameObject p)
    {
        speedingCars.Enqueue(p);
    }
    
    public GameObject RemoveSpeedingCar()
    {
        if (speedingCars.Count == 0) return null;
        return speedingCars.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
