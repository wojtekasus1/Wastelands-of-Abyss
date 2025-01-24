using UnityEngine;

public class AurasON : MonoBehaviour
{
    public GameObject RF;
    PlayerStatus status;

    void Start()
    {
        status = FindAnyObjectByType<PlayerStatus>();
    }

    void Update()
    {
        if (status.level >= 3)
        {
            RF.SetActive(true);
        }
        else
        {
            RF.SetActive(false);
        }
    }
}
