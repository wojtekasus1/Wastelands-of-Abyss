using UnityEngine;

[CreateAssetMenu(fileName = "AuraScriptableObject", menuName = "ScriptableObjects/Aura")]
public class AuraScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField]
    float speed;
    public float Speed { get => speed; private set => speed = value; }

    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }

    [SerializeField]
    float nextDamageTime;
    public float NextDamageTime { get => nextDamageTime; private set => nextDamageTime = value; }
    [SerializeField]
    float knockBackForce;
    public float KnockBackForce { get => knockBackForce; private set => knockBackForce = value;}
}
