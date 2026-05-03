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
            Timer.text = FormatTime(_Time);
            return;
        }
        

        _Time -= Time.deltaTime;
        if (TimeTaken < TimeFor0Score)
        {
            TimeTaken += Time.deltaTime;

        }
        Timer.text = FormatTime(_Time);
    }

    private string FormatTime(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        
        

        return string.Format("{0:00}:{1:00}", minutes, seconds);
 
    }

    private void DispayScore()
    {
        ScoreBoardDisplay.SetActive(true);
        ScoreText.text = Score.ToString();

    }

    void Start()
    {
        _Time = StartTime;
    }
}
