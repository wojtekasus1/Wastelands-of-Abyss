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
        PlayerExperience playerExperience = FindObjectOfType<PlayerExperience>();
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
