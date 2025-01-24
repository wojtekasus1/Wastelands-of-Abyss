using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private PlayerStatus ps;
    private float cdTimer = 5;
    public int damagePerSecond;
    public float burnDuration = 5f;
    private Coroutine damageCoroutine;
    void Start()
    {
        ps = FindAnyObjectByType<PlayerStatus>();
    }

    void Update()
    {
        cdTimer -= Time.deltaTime;  

        if(cdTimer < 0 )
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            damageCoroutine = StartCoroutine(ApplyDamageOverTime(ps));
    }

    private IEnumerator ApplyDamageOverTime(PlayerStatus ps)
    {
            float elapsed = 0f;
            while (elapsed < burnDuration)
            {
                ps.TakeDamage(damagePerSecond);
                elapsed += 1f; 
                yield return new WaitForSeconds(1f);
            }
    }
}
