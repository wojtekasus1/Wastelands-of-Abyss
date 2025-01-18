using System;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
   public EnemyScriptableObject enemyData;

    float currentMs;
    float currentHealth;
    float currentDamage;
    float currentAs;
    int xpValue;

    private void Awake()
    {
        currentMs = enemyData.MovementSpeed;
        currentHealth = enemyData.Health;
        currentDamage = enemyData.Damage;
        xpValue = 70;
    }

    public void TakeDamage(float dmg){
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerExperience playerExperience = FindFirstObjectByType<PlayerExperience>();
        if (playerExperience != null)
        {
            playerExperience.AddExperience(xpValue);
        }
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStatus player = col.gameObject.GetComponent<PlayerStatus>();
            player.TakeDamage(currentDamage);
        }
    }
}
