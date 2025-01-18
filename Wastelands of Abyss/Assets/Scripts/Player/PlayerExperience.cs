using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentExp;
    public int requiredXP;
    public int level;
    public Slider xpSlider;
    public Text levelText;

    public void AddExperience(int amount)
    {
        currentExp += amount;
        UpdateXPBar();
        if (currentExp >= requiredXP)
        {
            LevelUp();
        }

    }

    private void LevelUp()
    {
        level++;
        currentExp -= requiredXP;
        requiredXP = Mathf.RoundToInt(requiredXP * 1.2f); //Zwiekszenie wymaganego xp o 20% poprzedniej wartosci
        Debug.Log("Level Up! Nowy poziom: " + level);

        UpdateXPBar();
    }
    private void UpdateXPBar()
    {
        xpSlider.value = (float)currentExp / requiredXP;  // Aktualizowanie paska XP
        levelText.text = "Level: " + level;              // Aktualizowanie tekstu z poziomem
    }
}
