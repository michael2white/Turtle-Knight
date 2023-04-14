using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int scoreValue = 0;
    public static ScoreManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        scoreValue += value;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Gold: " + scoreValue.ToString();
    }
}
