using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public float destroyTime;
    protected virtual void Start()
    {
        Destroy(gameObject,destroyTime);
    }
    //public void DirectionChecker()
    //{

    //    if (dirx < 0 && diry == 0)
    //    {
    //        scale.x = scale.x * -1;
    //        scale.y = scale.y * -1;

    //    }
    //    transform.localScale = scale;
    //    transform.rotation = Quaternion.Euler(rotation);

    //}
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
