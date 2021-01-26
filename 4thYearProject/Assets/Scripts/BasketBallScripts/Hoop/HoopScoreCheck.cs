using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopScoreCheck : MonoBehaviour
{
    //Ticket

    //Audio Clips for Basket
   // public AudioSource sound1;
   // public AudioSource sound2;
    //public AudioSource sound3;

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
            //fireworks.GetComponent<ParticleSystem>().emission.enabled;
            Debug.Log("BASKET");

            fireworkss.Play();
            StartCoroutine(stopFireWorks());

          //  sound1.Play();
          //  sound2.Play();
           // sound3.Play();
        }

        //Instantiate(ticket);
    }

    IEnumerator stopFireWorks()
    {
        yield return new WaitForSeconds(3);
        fireworkss.Stop();
    }

}
