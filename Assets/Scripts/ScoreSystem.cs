using System;
using TMPro;
using UnityEngine;

using UnityEngine.Assertions.Comparers;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;

public class ScoreSystem : MonoBehaviour
{
    public float Score;
    public float TimeFor0Score;
    public float TimeTaken;
    public TMP_Text ScoreText;

    public void AddToScore()
    {
        Score += ((TimeTaken-TimeFor0Score)/TimeFor0Score)*-100;
        TimeTaken = 0;
    }


    public void ResetScore()
    {
        Score = 0;
        ScoreBoardDisplay.SetActive(false);
    }



    //Timer
    public float _Time;
    public float StartTime;
    public TMP_Text Timer;
    bool TimerRunning;
    public GameObject ScoreBoardDisplay;

    public void ResetTimer()
    {
        _Time = StartTime;
        TimerRunning = true;
    }


    public void Update()
    {
        if (_Time <= 0)
        {
            DispayScore();
            TimerRunning = false;
            _Time = 0;
            Timer.text = _Time.ToString();
            return;
        }
        

        _Time -= Time.deltaTime;
        if (TimeTaken < TimeFor0Score)
        {
            TimeTaken += Time.deltaTime;

        }
        Timer.text = _Time.ToString();
    }

    private void DispayScore()
    {
        ScoreBoardDisplay.SetActive(true);
        ScoreText.text = Score.ToString();

    }
}
