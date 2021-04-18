using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGameManager : MonoBehaviour
{
    //Singleton static instance
    public static CupGameManager instance;

    [SerializeField] GameObject cupStack;
    [SerializeField] Transform spawnPos;

    private int cupsKnocked;
    private int AMOUNT_CUPS_NEEDED = 5;

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
        CheckWin();
    }

    public void resetBasketScored()
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
}
