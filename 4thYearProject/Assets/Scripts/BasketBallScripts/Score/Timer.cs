using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
    bool timerOn = false;

    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        if(timerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerOn = false;
                BasketBallMiniGameManager.instance.resetBasketScored();
                timeRemaining = 60;
            }
        }

        scoreText.text = timeRemaining.ToString("00:00");

    }


    public void turnTimerOn()
    {
        timerOn = true;
        BasketBallMiniGameManager.instance.resetBasketScored();
        timeRemaining = 60;
    }


}
