using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource bgMusic;
    private PlayerMovement playerMovement;
    public TMP_Text pauseText;

    private void Start()
    {
        //gets references to bg music and player movement
        bgMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        playerMovement = GameObject.Find("TurtleKnight_Pixel").GetComponent<PlayerMovement>();
        pauseText = GameObject.Find("GamePaused").GetComponent<TMP_Text>();

        //disable Game Paused text at start
        pauseText.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f; //set time scale to 0 to pause game
        isPaused = true;
        bgMusic.Pause(); //pause bg music
        playerMovement.enabled = false; //disable player movement
        pauseText.gameObject.SetActive(true); //shows Game Paused when game is paused

    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; //set time scale to 1 to resume game
        isPaused = false;
        bgMusic.UnPause(); //resume bg music
        playerMovement.enabled = true; //enable player movement
        pauseText.gameObject.SetActive(false); //hides Game Paused when unpaused
    }
}
