using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRandomize : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            if (collision.gameObject.GetComponent<Enemy>().thisEnemyType == enemyType.yellow)
            {
                collision.gameObject.GetComponent<Enemy>().StopChangeSprite();
            }
            GameManager.instance.AddEnemyPool(collision.gameObject);
        }
    }
}