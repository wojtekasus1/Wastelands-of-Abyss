using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public PlayerScriptableObject playerData;

    float currentHealth;

    //I-Frames
    [Header("I-Frames")]
    public float invincibilityDuration;
    float invinicibilityTimer;
    bool isInvincible;
    void Awake()
    {
        currentHealth = playerData.Health;
    }
    void Update()
    {
        if (invinicibilityTimer > 0) 
        { 
            invinicibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }
    }

    public void TakeDamage(float dmg)
    {

        if (!isInvincible)
        {
            currentHealth -= dmg;

            invinicibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
                Kill();
        }
    }
    protected void Kill()
    {
            //Destroy(gameObject);
            Debug.Log("killed");
    }
}
