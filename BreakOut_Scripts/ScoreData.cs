using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    //Inspired by:https://www.youtube.com/watch?v=XOjd_qU2Ido

    public int highScore;


    public ScoreData()
    {
        highScore = UIScript.highScore;
    }

}
