using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void FixedUpdate()
    {
       // var distance = Vector3.Distance(player.transform.position, transform.position);

        var delta = player.transform.position - transform.position;
        delta.Normalize();

        var moveSpeed = speed * Time.deltaTime;

        transform.position = transform.position + (delta * moveSpeed);

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
       
    }

}
