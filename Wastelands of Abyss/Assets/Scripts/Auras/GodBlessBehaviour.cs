using UnityEngine;

public class GodBless : AurasBehaviour
{
   // public float knockbackForce = 0.5f;

    private float nextKnockbackTime;

    protected override void Update()
    {
        base.Update();

        if (Time.time >= nextKnockbackTime)
        {
            ApplyKnockbackToEnemies();
            nextKnockbackTime = Time.time + currentCooldownduration;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D enemyRigidbody = collision.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                enemyRigidbody.AddForce(knockbackDirection * currentKnockBackForce, ForceMode2D.Impulse);
            }
        }
    }

    private void ApplyKnockbackToEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
                if (enemyRigidbody != null)
                {
                    Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                    enemyRigidbody.AddForce(knockbackDirection * currentKnockBackForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
