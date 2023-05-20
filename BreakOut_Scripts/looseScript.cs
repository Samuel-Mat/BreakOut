using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class looseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int score = UIScript.scorePoints;
        int highScore = UIScript.highScore;
        TextMeshProUGUI scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
        scoreText.text = Convert.ToString(score);
        TextMeshProUGUI scoreAnswer = GameObject.Find("scoreAnswer").GetComponent<TextMeshProUGUI>();

        if (score > highScore)
        {
            UIScript.highScore = score;
            scoreAnswer.text = "Congratulations! You broke your Highscore!";
            SaveSystem.SaveScore();

        }
        else
        {
            scoreAnswer.text = "You didn't beat your Highscore";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
