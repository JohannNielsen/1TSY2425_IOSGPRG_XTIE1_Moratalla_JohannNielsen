using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform nozzle;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private TextMeshProUGUI gunText;
    [SerializeField] private TextMeshProUGUI reloadingText;

    

    
    public gunTypes thisGun;
    public int pistolAmmo;
    public int shotgunAmmo;
    public int assaultAmmo;

    public int pistolClip;
    public int shotgunClip;
    public int assaultClip;

    public TextMeshProUGUI ammoDisplay;

    public GameObject pistolPrefab;
    public GameObject shotgunPrefab;
    public GameObject assaultPrefab;
    public GameObject currentGun;
    public GameObject holsteredGun;
    public GameObject character;


    private int remainingBulletsInClip;
    //private bool isReloading = false;

    public Transform gunPosition;

    private float cooldownTime;
    private bool canShoot = true;

    public void Start()
    {
        ammoDisplay.text = GetCurrentAmmo().ToString();
    }
    void Update()
    {
        ammoDisplay.text = GetCurrentAmmo().ToString();
        
    }
    private int GetCurrentAmmo()
    {
        if (currentGun == pistolPrefab)
        {
            return pistolClip;
        }
        else if (currentGun == shotgunPrefab)
        {
            return shotgunClip;
        }
        else if (currentGun == assaultPrefab)
        {
            return assaultClip;
        }
        else
        {
            return 0; 
        }
    }
    public void EquipPistol()
    {
        if (currentGun != null)
        {
            Destroy(currentGun);
        }
        currentGun = Instantiate(pistolPrefab, gunPosition.position, gunPosition.rotation);
        currentGun.transform.parent = character.transform;
        thisGun = gunTypes.pistolGun;
        gunText.text = "pistol";
        
    }
    public void EquipShotgun()
    {
        if (currentGun != null)
        {
            Destroy(currentGun);
        }
        currentGun = Instantiate(shotgunPrefab, gunPosition.position, gunPosition.rotation);
        currentGun.transform.parent = character.transform;

        thisGun = gunTypes.shotgunGun;
        gunText.text = "shotgun";
    }
    public void EquipAssault()
    {
        if (currentGun != null)
        {
            Destroy(currentGun);
        }
        currentGun = Instantiate(assaultPrefab, gunPosition.position, gunPosition.rotation);
        currentGun.transform.parent = character.transform;
        thisGun = gunTypes.assaultGun;
        gunText.text = "assault";
    }
    public void HolsterAssault()
    {
        holsteredGun = assaultPrefab;
    }
    public void HolsterPistol()
    {
        holsteredGun = pistolPrefab;
    }
    public void HolsterShotgun()
    {
        holsteredGun = shotgunPrefab;
    }
    public void SwitchGun()
    {
        if (currentGun == assaultPrefab && holsteredGun == pistolPrefab)
        {
            Destroy(currentGun);
            currentGun = Instantiate(pistolPrefab, gunPosition.position, gunPosition.rotation);
            holsteredGun = assaultPrefab;
        }
        else if (currentGun == pistolPrefab && holsteredGun == assaultPrefab)
        {
            Destroy(currentGun);
            currentGun = Instantiate(assaultPrefab, gunPosition.position, gunPosition.rotation);
            holsteredGun = pistolPrefab;
        }
        else if (currentGun == pistolPrefab && holsteredGun == shotgunPrefab)
        {
            Destroy(currentGun);
            currentGun = Instantiate(shotgunPrefab, gunPosition.position, gunPosition.rotation);
            holsteredGun = pistolPrefab;
        }
        else if (currentGun == assaultPrefab && holsteredGun == shotgunPrefab)
        {
            Destroy(currentGun);
            currentGun = Instantiate(shotgunPrefab, gunPosition.position, gunPosition.rotation);
            holsteredGun = assaultPrefab;
        }
        else if (currentGun == shotgunPrefab && holsteredGun == pistolPrefab)
        {
            Destroy(currentGun);
            currentGun = Instantiate(pistolPrefab, gunPosition.position, gunPosition.rotation);
            holsteredGun = shotgunPrefab;
        }
        else if (currentGun == shotgunPrefab && holsteredGun == assaultPrefab)
        {
            Destroy(currentGun);
            currentGun = Instantiate(assaultPrefab, gunPosition.position, gunPosition.rotation);
            holsteredGun = shotgunPrefab;
        }
    }

    public void ReduceAmmo()
    {
        if (currentGun != null)
        {

            if (thisGun == gunTypes.pistolGun && pistolClip > 0)
            {
                StartCoroutine(ShootWithCooldownPistol(0.5f));
            }
            else if (thisGun == gunTypes.pistolGun && pistolClip <= 0)
            {
                StartCoroutine(PistolReload(2.0f));
            }

            if (thisGun == gunTypes.shotgunGun && shotgunClip > 0)
            {
                StartCoroutine(ShootWithCooldownShotGun(2.0f));
            }
            else if (thisGun == gunTypes.shotgunGun && shotgunClip <= 0)
            {
                StartCoroutine(ShotgunReload(2.7f));
            }

        }

    }
    public void ReduceAmmoAR()
    {
        if (currentGun != null)
        {


            if (thisGun == gunTypes.assaultGun && assaultClip > 0)
            {
                StartCoroutine(ShootWithCooldownAssaultRifle(0.25f));
            }
            else if (thisGun == gunTypes.assaultGun && assaultClip <= 0)
            {
                StartCoroutine(AssaultReload(2.3f));
            }

        }

    }
    private IEnumerator ShootWithCooldownPistol(float cooldown)
    {
        if (canShoot == true)
        {
            canShoot = false;

            

            pistolClip--;
            GameObject spawnBullet = Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);


            yield return new WaitForSeconds(cooldown);


            canShoot = true;
        }
    }

    private IEnumerator ShootWithCooldownShotGun(float cooldown)
    {
        if (canShoot == true)
        {
            canShoot = false;


            float initialRotation = -30 / 2f;

            for (int i = 0; i <= 8; i++)
            {
                float currentRotation = initialRotation + i * 10f;


                Quaternion bulletRotation = Quaternion.Euler(0, 0, currentRotation);


                Quaternion spawnRotation = nozzle.rotation * bulletRotation;


                GameObject spawnBullet = Instantiate(bulletPrefab, nozzle.position, spawnRotation);


                yield return null;

            }
            shotgunClip--;

            yield return new WaitForSeconds(cooldown);

            canShoot = true;
        }

    }

    private IEnumerator ShootWithCooldownAssaultRifle(float cooldown)
    {
        if (canShoot == true)
        {
            canShoot = false;

            assaultClip--;
            GameObject spawnBullet = Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);

            yield return new WaitForSeconds(cooldown);

            canShoot = true;
        }
    }

    private IEnumerator PistolReload(float cooldown)
    {
        if (canShoot == true)
        {
            canShoot = false;
            reloadingText.gameObject.SetActive(true);
            yield return new WaitForSeconds(cooldown);
            if (pistolAmmo >= 9)
            {
                pistolClip = 9;
                pistolAmmo = pistolAmmo - 9;
            }
            else
            {
                pistolClip = pistolAmmo;
                pistolAmmo = 0;
            }
            canShoot = true;
            reloadingText.gameObject.SetActive(false);
        }
    }

    private IEnumerator ShotgunReload(float cooldown)
    {
        if (canShoot == true)
        {
            canShoot = false;
            reloadingText.gameObject.SetActive(true);
            yield return new WaitForSeconds(cooldown);
            if (shotgunAmmo >= 15)
            {
                shotgunClip = 6;
                shotgunAmmo = shotgunAmmo - 6;
            }
            else
            {
                shotgunClip = shotgunAmmo;
                shotgunAmmo = 0;
            }
            canShoot = true;
            reloadingText.gameObject.SetActive(false);
        }
    }

    private IEnumerator AssaultReload(float cooldown)
    {
        if (canShoot == true)
        {
            canShoot = false;
            reloadingText.gameObject.SetActive(true);
            yield return new WaitForSeconds(cooldown);

            Debug.LogWarning("RELOADING....");
            if (assaultAmmo >= 30)
            {
                assaultClip = 30;
                assaultAmmo = assaultAmmo - 30;

            }
            else
            {
                assaultClip = assaultAmmo;
                assaultAmmo = 0;
            }
            canShoot = true;
            reloadingText.gameObject.SetActive(false);
        }
    }
}