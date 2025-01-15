using UnityEngine;

public class RotateAura : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
