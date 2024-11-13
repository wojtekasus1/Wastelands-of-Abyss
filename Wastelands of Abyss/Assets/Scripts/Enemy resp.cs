using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemyresp : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> spawnhandler;
    Timer timer;
    private int convertedTime;
    private int useCounter;
    float currentTime;
    private float cooldown = 10f;
    float currentCooldown;
    void Start()
    {
        currentCooldown = cooldown;
        timer = FindAnyObjectByType<Timer>();
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        currentCooldown = cooldown;
        for (int i = 0; i < 8; i++)
        {
            int random = Random.Range(0, spawnhandler.Count);
            Object.Instantiate(enemies[0], new Vector3(spawnhandler[i].transform.position.x, spawnhandler[random].transform.position.y), Quaternion.identity);
        }
    }
}
