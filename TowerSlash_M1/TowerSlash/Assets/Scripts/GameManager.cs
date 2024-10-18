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
    private GameObject gameOverScreen;

    public Spawner spawner;
    public Player player;
    public List<GameObject> enemyObjects = new List<GameObject>();
    public float timeScaleFactor = 2.0f;
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
                    
                }
            }
        }

    }

    public void KilledEnemy(int enemyNumber)
    {
        Destroy(enemyObjects[enemyNumber]);
        enemyObjects.RemoveAt(enemyNumber);
        enemyNumber--;
    }

    public void AddEnemyPool(GameObject enemy)
    {
        enemyObjects.Add(enemy);
    }
   
    public void ReturnSpeed()
    {
        Time.timeScale = 1.0f;
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
}