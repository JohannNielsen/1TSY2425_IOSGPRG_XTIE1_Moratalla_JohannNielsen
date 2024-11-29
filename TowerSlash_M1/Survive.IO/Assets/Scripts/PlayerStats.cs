using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public Image healthBar;

    private bool isDead;
    void Start()
    {
        GameManager.playerStats = this;

        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if(health <= 0 && !isDead)
        {
            isDead = true;
            Debug.Log("DEAD...");
        }
    }

    public void Die()
    {
        
    }
}
