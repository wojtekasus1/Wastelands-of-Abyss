using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Enemies : MonoBehaviour
{

    public EnemyScriptableObject EnemyData;
    protected GameObject player;
   // protected SwordController SC;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //SC = FindAnyObjectByType<SwordController>();
    }
    protected virtual void Update()
    {
        Move();
        //if(EnemyData.Health == 0)
        //    Destroy(gameObject);
    }
    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemyData.MovementSpeed * Time.deltaTime);
    }
   
    //protected virtual void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Weapon"))
    //    {
    //        EnemyData.health = EnemyData.Health - SC.weaponData.Damage;
    //    }

    //}
}
