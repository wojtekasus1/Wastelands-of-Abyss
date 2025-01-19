using UnityEngine;

public class AurasBehaviour : MonoBehaviour
{
    public AuraScriptableObject auraData;
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownduration;
    protected float currentNextDamageTime;
    protected float currentKnockBackForce;
    private void Awake()
    {
        currentCooldownduration = auraData.CooldownDuration;
        currentSpeed = auraData.Speed;
        currentDamage = auraData.Damage;
        currentNextDamageTime = auraData.NextDamageTime;
        currentKnockBackForce = auraData.KnockBackForce;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Rotate(0, 0, currentSpeed * Time.deltaTime);
    }
}
