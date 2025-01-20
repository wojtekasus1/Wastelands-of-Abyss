using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    Animator am;
    Enemy1 em;
    SpriteRenderer sprite;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        am = GetComponent<Animator>();
        em = GetComponent<Enemy1>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        DirectionChecker();
    }
    void DirectionChecker()
    {
        if (player.transform.position.x > transform.position.x) 
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
