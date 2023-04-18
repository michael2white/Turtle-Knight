using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;
    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TurtleKnight_Pixel" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false; //disables player movement with canMove from pm script
            collision.gameObject.GetComponent<PlayerMovement>().speed = 0f; // set player speed to zero
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // set player velocity to zero
            Invoke("LoadNextLevel", 1.5f);
        }
    }
    
    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
