using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PropRender : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        foreach (GameObject sp in propSpawnPoints)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            var prop = Instantiate(propPrefabs[rand],sp.transform.position, Quaternion.identity);
            prop.transform.parent = gameObject.transform;

        }
    }
}
