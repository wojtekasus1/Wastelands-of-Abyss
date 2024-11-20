using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementAndCamera : MonoBehaviour
{
    public float speed;
    //public Vector3 movement;
    Rigidbody2D rb;
    public Vector2 movement;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");


        //if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        //{
        //    movement = new Vector3(horizontal, vertical, 0).normalized;
        //    transform.position = transform.position + movement * speed * Time.deltaTime;


        //}
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;

        if (!Input.anyKey)
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(movement.x * speed, movement.y * speed);
        }
    }
}