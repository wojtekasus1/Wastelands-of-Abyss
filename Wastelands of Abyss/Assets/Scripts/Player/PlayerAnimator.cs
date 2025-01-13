using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator am;
    PlayerMovementAndCamera pm;
    SpriteRenderer sprite;
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovementAndCamera>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.movement.x !=0 || pm.movement.y != 0)
        {
            am.SetBool("Move", true);
            DirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }

        AttackAnim();
    }

    void DirectionChecker()
    {
        if(pm.movement.x > 0)
        {
            sprite.flipX = true;
        }
        else if(pm.movement.x < 0)
        {
            sprite.flipX = false;
        }
    }

    void AttackAnim()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            am.SetBool("Atk", true);
        }
        else
        {
            am.SetBool("Atk",false);
        }
       
    }
}
