using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCups : MonoBehaviour
{
    public float timeRemaining = 30;
    bool timerOn = false;

    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if (CupGameManager.instance.timerStarted)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                CupGameManager.instance.EvaluateScore();
                CupGameManager.instance.timerStarted = false;
                CupGameManager.instance.resetCupsScored();
                timeRemaining = 30;
            }
        }

        scoreText.text = timeRemaining.ToString("00:00");

    }


    public void turnTimerOn()
    {
        timerOn = true;
        CupGameManager.instance.resetCupsScored();
        timeRemaining = 60;
    }
}
