using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float health;
    public float movementSpeed;
    public float damage;
    public float attackSpeed;
    protected GameObject player;
    protected SwordController SC;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SC = FindAnyObjectByType<SwordController>();

    }

    // Update is called once per frame
    protected virtual void Update()
    { 
        Move();
        if(health == 0)
            Destroy(gameObject);
    }
    protected virtual void Move()
    { 
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            health = health - SC.damage;
        }

    }
}
