using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIDetection : MonoBehaviour
{
    public Enemy enemyDetection;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            // enemyDetection.player = collision.gameObject;
            enemyDetection.GetComponent<Enemy>().FaceTarget(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            enemyDetection.ReturnToRoam();
        }
    }
}
