using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            GameManager.instance.KilledEnemy(0);
            GameManager.instance.ReduceHealth();
        }
    }
}