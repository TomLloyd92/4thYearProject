using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backlog : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Ticket")
        {
            collider.GetComponent<Ticket>().freezeTicket();

            Debug.Log("YEHAW");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Ticket")
        {
            collider.GetComponent<Ticket>().unfreezeTicket();

            //collider.attachedRigidbody.useGravity = true;
            //ticket.useGravity = true;
            Debug.Log("OH NO");
        }
    }

}
