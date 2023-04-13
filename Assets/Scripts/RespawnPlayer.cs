using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{

    public Transform startingPoint;
    public float respawnDelay = 1f;
    public AudioClip deathSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = deathSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("TurtleKnight_Pixel"))
        {
            if(audioSource != null)
            {
                audioSource.Play();
            }
            Invoke("Respawn", respawnDelay);
        }
    }

    private void Respawn()
    {
        GameObject player = GameObject.FindGameObjectWithTag("TurtleKnight_Pixel");
        player.transform.position = startingPoint.position;
    }
}