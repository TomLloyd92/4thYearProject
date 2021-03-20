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
    public TicketState ticketState;
    private TicketState oldTicketState;

    HandPosition handPos;
    Vector3 boardPos;

    bool pickedUp = false;
    bool onBoard = false;

    static int currentId = 0;
    public int ID;
    private Rigidbody rb;

    private KanBanBoard kanban;

    private void Awake()
    {
        //On Start Ticket is Unpublished
        ticketState = TicketState.Unpublished;
        oldTicketState = TicketState.Unpublished;

        //Set Current Id
        ID = currentId;
        currentId++;

        rb = gameObject.GetComponent<Rigidbody>();

        kanban = GameObject.FindGameObjectWithTag("KanBanBoard").GetComponent<KanBanBoard>();
    }


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (ticketState != oldTicketState)
        {
            ticketStateUpdate();
        }

        //Picked up
        if (pickedUp)
        {
            transform.position = handPos.transform.position;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        //On Board
        else if (onBoard)
        {
            transform.position = boardPos;
        }
    }

    public void freezeTicket()
    {
        //rb.constraints = RigidbodyConstraints.FreezePositionX;
        //rb.constraints = RigidbodyConstraints.FreezePositionY;
        //rb.constraints = RigidbodyConstraints.FreezePositionZ;

        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

    }

    public void unfreezeTicket()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    public bool getActive()
    {
        return true;
    }

    public void SetOnBoard(Vector3 position)
    {
        //Freeze ticket while on board;
        freezeTicket();

        //Set position
        boardPos = position;

        //Set Bools
        pickedUp = false;
        onBoard = true;
    }

    public void SetPickedUp(bool t_pickedUp, HandPosition t_handPos)
    {
       handPos = t_handPos;
       transform.rotation = Quaternion.identity;
       transform.Rotate(0, -90, 0);
       onBoard = false;
       pickedUp = t_pickedUp;
    }

    private void ticketStateUpdate()
    {
        //Switch to handle updated ticket States
        switch (ticketState)
        {
            case TicketState.BackLog:
                kanban.GetBacklog().addTicket(this.gameObject.GetComponent<Ticket>());


                Debug.Log("BackLog");
                break;
            case TicketState.InDev:
                Debug.Log("InDev");
                break;
            case TicketState.Testing:
                Debug.Log("TESTING");
                break;
            case TicketState.Release:
                Debug.Log("RELEASE");
                break;
            default:
                Debug.Log("NOTHING");
                break;
        }


        //Set old TicketState to the new one
        oldTicketState = ticketState;
    }

}
