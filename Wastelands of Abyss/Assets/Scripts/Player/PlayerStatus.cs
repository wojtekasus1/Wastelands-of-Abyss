using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
            Destroy(gameObject); 
    }

}
