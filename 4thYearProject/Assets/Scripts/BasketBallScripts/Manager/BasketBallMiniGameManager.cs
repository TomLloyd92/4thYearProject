using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallMiniGameManager : MonoBehaviour
{
    //Singleton static instance
    public static BasketBallMiniGameManager instance;

    //Ticket
    [SerializeField] GameObject ticket;
    [SerializeField] Transform spawnPos;

    private int basketsScored;
    private int AMOUNT_BASKETS_NEEDED = 1;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public int GetBasketsScored()
    {
        return basketsScored;
    }

    // Start is called before the first frame update
    void Start()
    {
        basketsScored = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void increaseBasketScored()
    {
        basketsScored += 1;
        CheckWin();
    }

    public void resetBasketScored()
    {
        basketsScored = 0;
    }

    private void CheckWin()
    {
        if(basketsScored == AMOUNT_BASKETS_NEEDED )
        {
            Instantiate(ticket, spawnPos);
        }
    }

}
