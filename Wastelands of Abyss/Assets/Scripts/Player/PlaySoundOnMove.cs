using UnityEngine;

public class PlaySoundOnMove : MonoBehaviour
{
    public AudioSource audioSource;
    PlayerMovementAndCamera pm;

    private void Start()
    {
        pm = GetComponent<PlayerMovementAndCamera>();
    }
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            audioSource.enabled = true;
        }
        else 
        { 
            audioSource.enabled = false;
        }


    }
}