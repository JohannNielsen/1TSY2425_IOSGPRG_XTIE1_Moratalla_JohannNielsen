using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float startHealth = 100.0f;
    private float health;
    public Image healthBar;
    void Start()
    {
        health = startHealth;
        healthBar.fillAmount = health / startHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        this.health -= damage;
        this.healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
