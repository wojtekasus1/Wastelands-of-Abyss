using UnityEngine;

public class HpUp : MonoBehaviour
{
    PlayerStatus ps;
    private void Start()
    {
        ps = FindFirstObjectByType<PlayerStatus>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if(ps.currentHealth >= 80)
            {
                ps.currentHealth = 100;
            }
            else
            {
                ps.currentHealth += 20;
            }
            Destroy(gameObject);
        }
    }
}
