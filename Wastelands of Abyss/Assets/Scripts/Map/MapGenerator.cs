using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
public class MapGenerator : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public GameObject currentChunk;
    PlayerMovementAndCamera pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    public GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    string [] names;
    void Start()
    {
        pm = FindAnyObjectByType<PlayerMovementAndCamera>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }
    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }
        if (pm.movement.x > 0 && pm.movement.y == 0)//right
        {
            Direction( names = new string[] {"Right", "RightUp","RightDown" });
        }
        else if (pm.movement.x < 0 && pm.movement.y == 0)//left
        {
            Direction(names = new string[] { "Left", "LeftUp", "LeftDown" });
        }
        else if (pm.movement.x == 0 && pm.movement.y > 0)//up
        {
            Direction(names = new string[] { "Up", "RightUp", "LeftUp" });
        }
        else if (pm.movement.x == 0 && pm.movement.y < 0)//down
        {
            Direction(names = new string[] { "Down", "RightDown", "LeftDown" });
        }
        else if (pm.movement.x > 0 && pm.movement.y > 0)//right up
        {
            Direction(names = new string[] { "RightUp", "Right", "Up" });
        }
        else if (pm.movement.x > 0 && pm.movement.y < 0)//right down
        {
            Direction(names = new string[] { "RightDown", "Right", "Down" });
        }
        else if (pm.movement.x < 0 && pm.movement.y > 0)//left up
        {
            Direction(names = new string[] { "LeftUp", "Left", "Up" });
        }
        else if (pm.movement.x < 0 && pm.movement.y < 0)//left down
        {
            Direction(names = new string[] { "LeftDown", "Left", "Down" });
        }
    }
    void Direction(string[] name)
    {
        for (int i = 0; i < 3; i++)
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(name[i]).position, checkerRadius))
            {
                noTerrainPosition = currentChunk.transform.Find(name[i]).position;
                SpawnChunk();
            }
        }
    }
    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand],noTerrainPosition,Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist) {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }

        }
    }
}
