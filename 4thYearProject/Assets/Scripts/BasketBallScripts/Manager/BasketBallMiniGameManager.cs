using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallMiniGameManager : MonoBehaviour
{
    int basketsScored = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void increaseBasketScored()
    {
        basketsScored += 1;
    }

    public void resetBasketScored()
    {
        basketsScored = 0;
    }

}
