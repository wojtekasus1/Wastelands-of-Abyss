using UnityEngine;

public class SwordBehaviour : ProjectileWeaponBehaviour
{
     PlayerStatus status;
    protected override void Start()
    {
        status = FindAnyObjectByType<PlayerStatus>();
        base.Start();
    } 
    protected void Update()
    {
        if (status.level > 1)
        {
            currentPierce = 2;
        }
        else if (status.level > 2)
        {
            currentDamage = 2;
        }
    }
}
