using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameObject swipeObject;

    //private GameObject gameOverScreen;

    public Spawner spawner;
    public Player player;
    public List<GameObject> enemyObjects = new List<GameObject>();
    public float timeScaleFactor = 2.0f;
    public float boostedDuration = 0.3f;
    public bool boosted = false;
    public bool dashTap = false;
    public bool isAlive = true;

    public bool isSpeedRun = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {

    }
    private void Update()
    {
        if (swipeObject != null)
        {
            for (int i = 0; i < enemyObjects.Count; i++)
            {
                if (swipeObject.GetComponent<TouchInputs>()._swipeDirections == enemyObjects[i].GetComponent<Enemy>().thisEnemyDirection)
                {
                    KilledEnemy(i);                    
                    PowerUp();
                    if (isSpeedRun == false)
                    {
                        PlayerStats.instance.IncreaseEnergy(20.0f);
                    }
                    else if (isSpeedRun == true)
                    {
                        PlayerStats.instance.IncreaseEnergy(50.0f);
                    }
                }
            }
            if (boosted)
            {
                Time.timeScale = timeScaleFactor;
            }
            else if (!boosted && !dashTap)
            {
                Time.timeScale = 1.0f;
            }
        }

    }

    public void Boosted()
    {
        boosted = true;
        Time.timeScale = timeScaleFactor;
        Invoke(nameof(Unboost), 20.0f);
    }

    public void KilledEnemy(int enemyNumber)
    {
        Destroy(enemyObjects[enemyNumber]);
        enemyObjects.RemoveAt(enemyNumber);
        enemyNumber--;
    }

    public void PowerUp()
    {
        int powerUpChance = Random.Range(0, 100);
        if (powerUpChance < 3)
        {
            PlayerStats.instance.IncreaseHealth();
        }
    }
    public void AddEnemyPool(GameObject enemy)
    {
        enemyObjects.Add(enemy);
    }
    public void DashTap()
    {
        Time.timeScale = timeScaleFactor;
    }
    public void ReturnSpeed()
    {
        Time.timeScale = 1.0f;
    }
    public bool GetBoolBoosted()
    {
        return boosted;
    }
    public void SetBoostedBool(bool setThisBool)
    {
        boosted = setThisBool;
    }
    public void ReduceHealth()
    {
        if (!boosted)
        {
            PlayerStats.instance.DecreaseHealth();
        }
        else if (boosted)
        {

        }
        PlayerStats.instance.HealthCheck();
    }
    public bool GetBoolDashTap()
    {
        return dashTap;
    }
    public void SetBoolDashTap(bool setThisBool)
    {
        dashTap = setThisBool;
    }

    public void Unboost()
    {
        boosted = false;
    }
    public void PlayerDeath()
    {
        isAlive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public bool GetIsAlive()
    {
        return isAlive;
    }
    public void SetIsAlive(bool setIsAlive)
    {
        isAlive = setIsAlive;
    }
    public void ResetValues()
    {
        foreach (GameObject obj in enemyObjects)
        {
            Destroy(obj);
        }
        enemyObjects.Clear();
    }
    public void SetupSwiping(GameObject swiping)
    {
        swipeObject = swiping;
    }
    public void SetupEndScreen(GameObject EndScreen)
    {
        //gameOverScreen = EndScreen;
    }
}