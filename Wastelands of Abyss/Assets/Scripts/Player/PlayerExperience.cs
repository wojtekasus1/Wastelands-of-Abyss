using UnityEngine;
public class PlayerExperience : MonoBehaviour
{
    public float currentXP = 0;
    public float requiredXP = 100;
    public float level = 1;

    public void AddExperience(float amount)
    {
        currentXP += amount;

        if (currentXP >= requiredXP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        currentXP -= requiredXP;
        requiredXP = Mathf.RoundToInt(requiredXP * 1.2f); // Kolejny poziom zwiekszy req xp o 20%
        Debug.Log("Level Up! Nowe poziom: " + level);
    }
}
