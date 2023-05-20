using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static int scorePoints = 0;
    public static int highScore = 0;
    public int hearts = 3;


    // Start is called before the first frame update
    void Start()
    {
        scorePoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int points)
    {
        scorePoints += points;
        TextMeshProUGUI score = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        score.text = "Score: " + scorePoints;

    }

    public void IncreaseLives()
    {
        hearts++;
        TextMeshProUGUI lives = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        lives.text = "Lives: " + hearts;
    }

    public void DecreaseLives()
    {
        hearts--;
        TextMeshProUGUI lives = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        lives.text = "Lives: " + hearts;

        if(hearts < 0)
        {
            SceneManager.LoadScene(2);
        }
            
    }
}
