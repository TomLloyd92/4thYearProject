using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGameManager : MonoBehaviour
{
    [SerializeField] Release release;

    //Singleton static instance
    public static CupGameManager instance;

    public bool timerStarted = false;

    [SerializeField] GameObject cupStack;
    [SerializeField] Transform spawnPos;

    private int cupsKnocked;
    private int AMOUNT_CUPS_NEEDED = 5;

    public void startTimer()
    {
        timerStarted = true;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public int GetCupsKnocked()
    {
        return cupsKnocked;
    }


    public void increaseCupsKnocked()
    {
        cupsKnocked+= 1;
        //CheckWin();
    }

    public void resetCupsScored()
    {
        cupsKnocked = 0;
    }

    private void CheckWin()
    {
        if (cupsKnocked == AMOUNT_CUPS_NEEDED)
        {
            Debug.Log("Winner");
            //Instantiate(ticket, spawnPos);
        }
    }

    public void EvaluateScore()
    {
        Debug.Log("Entered");

        int ammountToRelease = cupsKnocked / 10;

        if(release.tickets == null)
        {
            Debug.Log($"You got {ammountToRelease} but there is no tickets in release lol");
            return;
        }

        if(ammountToRelease > release.tickets.Count)
        {
            ammountToRelease = release.tickets.Count;
        }

        for (int i = 0; i < ammountToRelease - 1; i++)
        {
            release.tickets[i].ticketState = Ticket.TicketState.ReleaseDone;
        }
    }


}
