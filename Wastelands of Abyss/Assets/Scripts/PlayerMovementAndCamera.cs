using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementAndCamera : MonoBehaviour
{
    public float speed;
    public Camera camera;
    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float x = transform.position.x;
        float y = transform.position.y;


        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            transform.position = transform.position + new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
        }
        camera.transform.position = new Vector3(x, y);
    }
}
