using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlateBehaviour : MonoBehaviour
{
    bool isActive = true;
    public List<GameObject> prefab;
    public GameObject HealthPrefab;
    private GameObject cPrefab;
    private GameObject tfab;
    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && isActive == true)
        {
            isActive = false;

            Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(-2f,2f), transform.position.y + Random.Range(-2f,2f));
            Instantiate(HealthPrefab, spawnPosition, Quaternion.identity);

            setPlatePosition();



        }
    }
    void setPlatePosition()
    {

        cPrefab = prefab[Random.Range(0, prefab.Count)];

        for (int i = -3; i <= 3; i++)
        {
            for (int j = -3; j <= 3; j++)
            {
                if (i == -3 || i == 3)
                {
                    tfab = Instantiate(cPrefab, transform.position, Quaternion.identity);
                    tfab.transform.position = new Vector2(transform.position.x + i, transform.position.y + j);
                    tfab.transform.parent = gameObject.transform;
                }
                if ((j == -3 || j == 3) && i != -3 && i != 3)
                {
                    tfab = Instantiate(cPrefab, transform.position, Quaternion.identity);
                    tfab.transform.position = new Vector2(transform.position.x + i, transform.position.y + j);
                    tfab.transform.parent = gameObject.transform;
                }
            }

        }
    }
   
}


