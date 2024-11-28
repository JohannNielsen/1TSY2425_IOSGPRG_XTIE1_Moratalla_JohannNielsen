using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunFire : MonoBehaviour
{
    [SerializeField] private Inventory bulletInventory;
    [SerializeField] private Transform nozzle;
    [SerializeField] private GameObject bulletPrefab;

    private bool isHolding = false;

    public void IsOnHold()
    {
        isHolding = true;
    }
    public void OnRelease()
    {
        isHolding = false;
    }
    public void Update()
    {
        if (isHolding == true)
        {
            bulletInventory.ReduceAmmoAR();
        }
    }
    public void Firing()
    {
        bulletInventory.ReduceAmmo();
        Debug.Log("Fire");
    }
}