using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private GameObject _house;
    [SerializeField] private GameObject _repairShop;
    private bool _spawningHouse;
    private bool _spawningRepairShop;
    private int _layerMask;
    public float _balance;
    [SerializeField] private TMP_Text _moneyText;

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;

        if (_spawningHouse)
        {
            _spawningHouse = false;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, _layerMask))
            {
                Instantiate(_house, hit.point, Quaternion.identity);
            }
        }

        if (_spawningRepairShop)
        {
            _spawningRepairShop = false;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, _layerMask))
            {
                Instantiate(_repairShop, hit.point, Quaternion.identity);
            }
        }
    }

    public void OnSpawnHouse(float cost)
    {
        if (cost > _balance)
        {
            Debug.Log("NOT ENOUGH MONEY FOR HOUSE");
            return;
        }

        UpdateTotalBalance(-cost);
        _spawningHouse = true;
    }

    public void OnSpawnRepairShop(float cost)
    {
        if (cost > _balance)
        {
            Debug.Log("NOT ENOUGH MONEY FOR REPAIR SHOP");
            return;
        }

        UpdateTotalBalance(-cost);
        _spawningRepairShop = true;
    }

    public void improvePatience(float cost)
    {
        if (cost > _balance)
        {
            Debug.Log("NOT ENOUGH MONEY FOR PATIENCE");
            return;
        }
        UpdateTotalBalance(-cost);
        EventManager.current.IncreasePatience(1.5f);
    }

    public void ImproveGasoline(float cost)
    {
        if (cost > _balance)
        {
            Debug.Log("NOT ENOUGH MONEY FOR GAS");
            return;
        }
        UpdateTotalBalance(-cost);
        EventManager.current.IncreaseGas(1.5f);
    }

    public void UpdateTotalBalance(float moneyDelta)
    {
        _balance += moneyDelta;
        _moneyText.text = "Total Balance: " + _balance + "$";
    }
}