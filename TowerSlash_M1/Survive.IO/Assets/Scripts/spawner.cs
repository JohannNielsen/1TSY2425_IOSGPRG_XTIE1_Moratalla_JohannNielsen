using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemies;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            float randomX = Random.Range(-20f, 20f);
            float randomY = Random.Range(-15f, 15f);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(enemies, spawnPosition, Quaternion.identity);
        }
    }
}