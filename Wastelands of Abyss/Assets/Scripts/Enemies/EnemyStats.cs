using UnityEngine;

public class EnemyStats : MonoBehaviour
{
   public EnemyScriptableObject enemyData;

    float currentMs;
    float currentHealth;
    float currentDamage;
    float currentAs;

    public float despawnDistance = 20f;
    Transform player;

     void Start()
    {
        player = FindAnyObjectByType<PlayerStatus>().transform;
    }
     void Update()
    {
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
    }
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

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStatus player = col.gameObject.GetComponent<PlayerStatus>();
            player.TakeDamage(currentDamage);
        }
    }

     void OnDestroy()
    {
        EnemySpawner es = FindAnyObjectByType<EnemySpawner>();
        es.OnEnemyKilled();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindAnyObjectByType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}
