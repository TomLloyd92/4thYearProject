using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopScoreCheck : MonoBehaviour
{
    //Particle Transform for Basket
    public Transform fireworks;

    public ParticleSystem fireworkss;

    // Start is called before the first frame update
    void Start()
    {
       // fireworks.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "BasketBall" )
        {
            BasketBallMiniGameManager.instance.increaseBasketScored();
            


            Debug.Log(BasketBallMiniGameManager.instance.GetBasketsScored());
        }
    }

    IEnumerator stopFireWorks()
    {
        yield return new WaitForSeconds(3);
        fireworkss.Stop();
    }

}
