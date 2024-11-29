using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject[] ammos;



    private void Start()
    {

        for (int i = 0; i < 15; i++)
        {
            float randomX = Random.Range(-18f, 18f);
            float randomY = Random.Range(-14f, 14f);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(enemies, spawnPosition, Quaternion.identity);
        }

        //ammo
        for (int i = 0; i < 20; i++)
        {
            float randomX = Random.Range(-12f, 12f);
            float randomY = Random.Range(-8f, 8f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            GameObject objectToSpawn = GetRandomObject(ammos);

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
    private GameObject GetRandomObject(GameObject[] objectArray)
    {
        // Get a random object from the array
        int randomIndex = Random.Range(0, objectArray.Length);
        return objectArray[randomIndex];
    }
}