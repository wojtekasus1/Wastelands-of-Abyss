using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    private int wallHp = 4;

    private void Update()
    {
        if(wallHp < 0)
            Destroy(gameObject);
    }
  
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Weapon"))
        {
            wallHp--;
        }
    }
}
