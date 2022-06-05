using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnCars : MonoBehaviour
{
    [SerializeField] private GameObject _carReference;
    private float _timeCounter;
    int _spawnCounter;
    [SerializeField] private int _spawnLimit;


    private void Start()
    {
        _spawnCounter = 0;
        InvokeRepeating(nameof(InstantiateACar), Random.Range(50, 150), Random.Range(50, 150));
    }

    private void InstantiateACar()
    {
        if (_spawnCounter < _spawnLimit)
        {
            GameObject car = Instantiate(_carReference, transform);
            car.GetComponent<NavMeshAgent>().Warp(transform.position);
            car.GetComponent<ReturnHome>().target = this.gameObject;
            
            var offices = GameObject.FindGameObjectsWithTag("Office");
            GameObject closestOffice = null;
            foreach (var office in offices)
            {
                float distanceToOffice = Vector3.Distance(car.transform.position, office.transform.position);
                if (closestOffice == null)
                {
                    closestOffice = office;
                    continue;
                }
                float distanceToClosestOffice = Vector3.Distance(car.transform.position, closestOffice.transform.position);
                if (distanceToOffice < distanceToClosestOffice)
                {
                    closestOffice = office;
                }
            }
            
            car.GetComponent<GoToWork>().target = closestOffice;
            _spawnCounter++;
        }
    }
    

}
