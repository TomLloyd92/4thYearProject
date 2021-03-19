using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public enum TicketState
    {
        Unpublished,
        BackLog,
        InDev,
        Testing,
        Release,
        Done
    }

    GameObject handPos;


    public TicketState ticketState;

    bool pickedUp = false;

    static int currentId = 0;
    public int ID;
    private Rigidbody rb;

    private void Awake()
    {
        //On Start Ticket is Unpublished
        ticketState = TicketState.Unpublished;

        //Set Current Id
        ID = currentId;
        currentId++;


        rb = gameObject.GetComponent<Rigidbody>();

        handPos = GameObject.FindGameObjectWithTag("ScrumMaster");
    }


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(pickedUp)
        {
            transform.position = handPos.transform.position;
        }
    }

    public void freezeTicket()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    public void unfreezeTicket()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    public bool getActive()
    {
        return true;
    }

    public void SetPickedUp(bool t_pickedUp)
    {
        pickedUp = t_pickedUp;
    }

}
