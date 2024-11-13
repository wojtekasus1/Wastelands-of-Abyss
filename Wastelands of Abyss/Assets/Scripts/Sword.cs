using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Rigidbody2D rb;

    private GameObject player;
    private GameObject latestShoot;
    private float dist;

    public GameObject weapon;
    public float speed;
    public float destroyTime;
    public float cooldown;


    float currentCooldown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCooldown = cooldown;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        currentCooldown = cooldown;
        var playerPosition = player.transform.position;
        if (Input.GetKey(KeyCode.UpArrow) /*&& !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)*/)
        {
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.5f, 0);
            latestShoot = Instantiate(weapon, transform.position, Quaternion.identity);
            latestShoot.transform.eulerAngles = new Vector3(0, 0, 90);
            rb = latestShoot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(0, speed);
            Destroy(latestShoot, destroyTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow) /*&& !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)*/)
        {
            transform.position = new Vector3(playerPosition.x, playerPosition.y - 0.5f, 0);
            latestShoot = Instantiate(weapon, transform.position, Quaternion.identity);
            latestShoot.transform.eulerAngles = new Vector3(0, 0, -90);
            rb = latestShoot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(0, -speed);
            Destroy(latestShoot, destroyTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)/* && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) */)
        {
            transform.position = new Vector3(playerPosition.x + 0.5f, playerPosition.y);
            latestShoot = Instantiate(weapon, transform.position, Quaternion.identity);
            rb = latestShoot.GetComponent<Rigidbody2D>();
            rb.linearVelocity =  new Vector2(speed, 0);
            Destroy(latestShoot, destroyTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)/* && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow)*/)
        {
            transform.position = new Vector3(playerPosition.x - 0.5f, playerPosition.y);
            latestShoot = Instantiate(weapon, transform.position, Quaternion.identity);
            latestShoot.transform.eulerAngles = new Vector3(0,0,180);
            rb = latestShoot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(-speed, 0);
            Destroy(latestShoot, destroyTime);
        }


    }
 
}
