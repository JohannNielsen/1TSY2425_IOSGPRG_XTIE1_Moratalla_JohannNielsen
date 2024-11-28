using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("I didn't hit anything.");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerMovement>() != null)
        {
            Destroy(this.gameObject);
            //add minus player health
        } 
        Debug.Log("ShotMyself");
        Destroy(this.gameObject, 5.0f);
    }

}