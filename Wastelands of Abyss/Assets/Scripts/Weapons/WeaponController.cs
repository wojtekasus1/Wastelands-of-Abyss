using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected PlayerMovementAndCamera pm;
    protected virtual void Start()
    {
        pm = FindAnyObjectByType<PlayerMovementAndCamera>();
        currentCooldown = cooldownDuration;
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0) {
            Attack();
        }
    }
    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
