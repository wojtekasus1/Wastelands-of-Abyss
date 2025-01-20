using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentExp;
    public int requiredXP;
    public int level;
    public Material radialMaterial;
    public Text levelText;

    public void AddExperience(int amount)
    {
        currentExp += amount;

        if (currentExp >= requiredXP)
        {
            LevelUp();
        }

        UpdateXPBar();
    }

    private void LevelUp()
    {
        level++;
        currentExp -= requiredXP;
        requiredXP = Mathf.RoundToInt(requiredXP * 1.2f); 
        Debug.Log("Level Up! Nowy poziom: " + level);
    }

    private void UpdateXPBar()
    {
        float progress = (float)currentExp / requiredXP;

        radialMaterial.SetFloat("_Progress", progress);

        levelText.text = "Level: " + level;
    }
}
