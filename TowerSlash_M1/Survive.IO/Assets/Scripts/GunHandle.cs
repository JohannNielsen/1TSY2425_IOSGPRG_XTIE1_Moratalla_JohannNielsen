using UnityEngine;

public class GunHandle : MonoBehaviour
{
    [SerializeField] private gunTypes thisGun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            if (thisGun == gunTypes.pistolGun && collision.GetComponent<Inventory>().holsteredGun == null && collision.GetComponent<Inventory>().currentGun == null)
            {
                collision.GetComponent<Inventory>().EquipPistol();
            }
            else if (thisGun == gunTypes.shotgunGun && collision.GetComponent<Inventory>().holsteredGun == null && collision.GetComponent<Inventory>().currentGun == null)
            {
                collision.GetComponent<Inventory>().EquipShotgun();
            }
            else if (thisGun == gunTypes.assaultGun && collision.GetComponent<Inventory>().holsteredGun == null && collision.GetComponent<Inventory>().currentGun == null)
            {
                collision.GetComponent<Inventory>().EquipAssault();
            }
            else if (thisGun == gunTypes.assaultGun && collision.GetComponent<Inventory>().holsteredGun == null && collision.GetComponent<Inventory>().currentGun != null)
            {
                collision.GetComponent<Inventory>().HolsterAssault();
            }
            else if (thisGun == gunTypes.pistolGun && collision.GetComponent<Inventory>().holsteredGun == null && collision.GetComponent<Inventory>().currentGun != null)
            {
                collision.GetComponent<Inventory>().HolsterPistol();
            }
            else if (thisGun == gunTypes.shotgunGun && collision.GetComponent<Inventory>().holsteredGun == null && collision.GetComponent<Inventory>().currentGun != null)
            {
                collision.GetComponent<Inventory>().HolsterShotgun();
            }
            else if (thisGun == gunTypes.shotgunGun && collision.GetComponent<Inventory>().holsteredGun != null && collision.GetComponent<Inventory>().currentGun != null)
            {
                collision.GetComponent<Inventory>().EquipShotgun();
            }
            else if (thisGun == gunTypes.assaultGun && collision.GetComponent<Inventory>().holsteredGun != null && collision.GetComponent<Inventory>().currentGun != null)
            {
                collision.GetComponent<Inventory>().EquipAssault();
            }
            else if (thisGun == gunTypes.pistolGun && collision.GetComponent<Inventory>().holsteredGun != null && collision.GetComponent<Inventory>().currentGun != null)
            {
                collision.GetComponent<Inventory>().EquipPistol();
            }
            Destroy(gameObject);
        }
    }
}