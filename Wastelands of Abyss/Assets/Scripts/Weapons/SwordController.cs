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

    [SerializeField] public float speed = 5f;
    [SerializeField] private GameObject prefab; 

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Attack()
    {
        base.Attack();

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                float diagonalSpeed = speed / Mathf.Sqrt(2);
                AttackHelper(0f, 0.5f, 45, diagonalSpeed, diagonalSpeed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                float diagonalSpeed = speed / Mathf.Sqrt(2);
                AttackHelper(0f, 0.5f, 135, -diagonalSpeed, diagonalSpeed);
            }
            else
            {
                AttackHelper(0f, 0.5f, 90, 0, speed);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                float diagonalSpeed = speed / Mathf.Sqrt(2);
                AttackHelper(0f, 0.5f, -45, diagonalSpeed, -diagonalSpeed);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                float diagonalSpeed = speed / Mathf.Sqrt(2);
                AttackHelper(0f, 0.5f, -135, -diagonalSpeed, -diagonalSpeed);
            }
            else
            {
                AttackHelper(0f, 0.5f, -90, 0, -speed);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            AttackHelper(0f, 0.5f, 0, speed, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            AttackHelper(0f, 0.5f, 180, -speed, 0);
        }
    }

    protected virtual void AttackHelper(float posx, float posy, int angle, float speedx, float speedy)
    {
        var playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x + posx, playerPosition.y + posy, 0);
        latestShoot = Instantiate(prefab, transform.position, Quaternion.identity);
        latestShoot.transform.eulerAngles = new Vector3(0, 0, angle);
        rb = latestShoot.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(speedx, speedy);
    }
}
