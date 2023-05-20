using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(938, 503, false);
        ScoreData data = SaveSystem.LoadScore();
        UIScript.highScore = data.highScore;
        int highScore = UIScript.highScore;
   
        TextMeshProUGUI scoreText = GameObject.Find("highscore").GetComponent<TextMeshProUGUI>();
        scoreText.text = Convert.ToString("Highscore: " + highScore);
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
