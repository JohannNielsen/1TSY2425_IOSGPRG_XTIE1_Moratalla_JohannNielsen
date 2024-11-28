using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private ammoTypes bulletType;
    [SerializeField] private int clipSize;

    private void Start()
    {
        clipSize = Random.Range(1, 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            if (bulletType == ammoTypes.pistol)
            {
                collision.GetComponent<Inventory>().pistolAmmo += clipSize;
            }
            else if (bulletType == ammoTypes.shotgun)
            {
                collision.GetComponent<Inventory>().shotgunAmmo += clipSize;
            }
            else if (bulletType == ammoTypes.assault)
            {
                collision.GetComponent<Inventory>().assaultAmmo += clipSize;
            }
            Destroy(gameObject);
        }
    }
}