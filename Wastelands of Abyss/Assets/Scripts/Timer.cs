using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    public float TimeLeft;
    public Text TimerTXT;
    public Text LevelTXT;
    public Text ExpTXT;
    public Text HealthTXT;
    public bool TimerOn = false;

    PlayerStatus pstatus;
    void Start()
    {
       pstatus = FindAnyObjectByType<PlayerStatus>();
    }
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
            }
        }
        updateExpAndLevel(pstatus.exp,pstatus.level,pstatus.experienceCap);
        ShowHealth(pstatus.currentHealth);
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerTXT.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void updateExpAndLevel(int exp, int level, int cap)
    {
        LevelTXT.text = $"Level: {level}";
        float wynik = ((float)exp / (float)cap) * 100;
        ExpTXT.text = $"Exp: {(int)wynik}%";
    }

    void ShowHealth(float health)
    {
        HealthTXT.text = $"Health: {(int)health}";
    }
}
