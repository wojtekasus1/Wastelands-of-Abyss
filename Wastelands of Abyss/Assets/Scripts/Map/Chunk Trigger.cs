using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapGenerator mc;
    public GameObject targetMap;
    void Start()
    {
        mc = FindAnyObjectByType<MapGenerator>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            mc.currentChunk = targetMap;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (mc.currentChunk == targetMap)
                mc.currentChunk = null;
        }
    }
}
