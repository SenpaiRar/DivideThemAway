using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public Text ScoreText;
    int currentScore;

    private void Start()
    {
        currentScore = 0;
        ScoreText.text = currentScore + "x";
    }
    public void AddScore(int Number)
    {
        currentScore += Number;
        Debug.Log("Chaged score");
        ScoreText.text = currentScore.ToString() +"x";
    }
}
