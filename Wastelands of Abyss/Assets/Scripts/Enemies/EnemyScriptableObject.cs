using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]

public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField]
    float health;
    public float Health { get => health; private set => health = value; }


    [SerializeField]
    float movementSpeed;
    public float MovementSpeed { get => movementSpeed; private set => movementSpeed = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }


}
