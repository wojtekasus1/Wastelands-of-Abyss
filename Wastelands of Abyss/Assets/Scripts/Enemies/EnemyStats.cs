using UnityEngine;

public class EnemyStats : MonoBehaviour
{
   public EnemyScriptableObject enemyData;

    float currentMs;
    float currentHealth;
    float currentDamage;
    float currentAs;

    private void Awake()
    {
        currentMs = enemyData.MovementSpeed;
        currentHealth = enemyData.Health;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg){
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);    
        }

    }
}
