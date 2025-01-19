using System.Collections.Generic;
using UnityEngine;

public class AuraBehaviour : AurasBehaviour
{

    private List<Collider2D> enemiesInAura = new List<Collider2D>();

    protected override void Update()
    {
        base.Update();
        
        if (Time.time >= currentNextDamageTime)
        {
            ApplyDamageToEnemies();
            currentNextDamageTime = Time.time + currentCooldownduration;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!enemiesInAura.Contains(collision))
            {
                enemiesInAura.Add(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemiesInAura.Remove(collision);
        }
    }

    private void ApplyDamageToEnemies()
    {
        for (int i = enemiesInAura.Count - 1; i >= 0; i--)
        {
            Collider2D enemyCollider = enemiesInAura[i];

            if (enemyCollider == null) 
            {
                enemiesInAura.RemoveAt(i);
                continue;
            }

            EnemyStats enemy = enemyCollider.GetComponent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(currentDamage);
            }
            else
            {
                enemiesInAura.RemoveAt(i); 
            }
        }
    }
}
