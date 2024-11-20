using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class SwordController : WeaponController
{
    Rigidbody2D rb;
    private GameObject player;
    private GameObject latestShoot;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Attack()
    {
        base.Attack();

        if (Input.GetKey(KeyCode.UpArrow))
        {
            AttackHelper(0f, 0.5f, 90, 0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            AttackHelper(0f, -0.5f, -90, 0, -speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            AttackHelper(0.5f, 0, 0, speed, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            AttackHelper(-0.5f, 0, 180, -speed, 0);
        }
    }
    protected virtual void AttackHelper(float posx, float posy, int angel, float speedx, float speedy)
    {
        var playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x + posx, playerPosition.y + posy, 0);
        latestShoot = Instantiate(prefab, transform.position, Quaternion.identity);
        latestShoot.transform.eulerAngles = new Vector3(0, 0, angel);
        rb = latestShoot.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(speedx, speedy);
    }
}
