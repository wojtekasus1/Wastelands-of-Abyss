using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public PlayerScriptableObject playerData;

    public float currentHealth;

    //I-Frames
    [Header("I-Frames")]
    public float invincibilityDuration;
    float invinicibilityTimer;
    bool isInvincible;

    [Header("Exp")]
    public int exp = 0;
    public int level = 1;
    public int experienceCap = 100;
    public int experienceCapIncrease;

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

    public void IncreaseExp(int amount)
    {
        exp += amount;
        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if(exp >= experienceCap)
        {
            level++;
            exp -= experienceCap;
            experienceCap += experienceCapIncrease;
        }
    }
}
