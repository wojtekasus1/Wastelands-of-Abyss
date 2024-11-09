using UnityEngine;

public class Enemyresp : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject[] spawnhandler;
    void Start()
    {
        for (int i = 0; i < 8; i++) {
        Object.Instantiate(enemy1, new Vector3(spawnhandler[i].transform.position.x, spawnhandler[i].transform.position.y),Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
