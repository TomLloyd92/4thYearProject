using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpTicket : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private Animator anim;
    private Transform handPos;

    private GameObject[] tickets;

    float timer = 0;
    float waitTime = 5;

    public PickUpTicket(ScrumMaster t_sm, Animator t_anim, Transform t_handPos)
    {
        this.scrumMaster = t_sm;
        this.anim = t_anim;
        handPos = t_handPos;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if(scrumMaster.ticketPickedUp)
        {
            return state.Success;
        }

        //Start Pick Up Ticket
        anim.SetBool("isMovingTicket", true);

        timer += Time.deltaTime;
        tickets = GameObject.FindGameObjectsWithTag("Ticket");

        //Put Ticket in hand
        if (tickets.Length > 0)
        {
            foreach (GameObject ticket in tickets)
            {

                if (ticket.GetComponent<Ticket>().ticketState == Ticket.TicketState.Unpublished)
                {
                    //ticket.transform.position = handPos.position;
                    //ticket.GetComponent<Ticket>().ticketState = Ticket.TicketState.PickedUp;
                    ticket.GetComponent<Ticket>().SetPickedUp(true);
                    break;
                }
            }
        }

        if (timer > waitTime)
        {
            scrumMaster.ticketPickedUp = true;
            anim.SetBool("isMovingTicket", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}
