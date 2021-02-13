using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void freezeTicket()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    public void unfreezeTicket()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

}
