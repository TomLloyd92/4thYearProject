using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTicketOnBoard : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private Animator anim;

    private GameObject[] tickets;


    float timer = 0;
    float waitTime = 5;

    public PlaceTicketOnBoard(ScrumMaster t_sm, Animator t_anim)
    {
        this.scrumMaster = t_sm;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (!scrumMaster.ticketPickedUp)
        {
            return state.Success;
        }

        //Start Pick Up Ticket
        anim.SetBool("isMovingTicket", true);

        timer += Time.deltaTime;
        tickets = GameObject.FindGameObjectsWithTag("Ticket");

        if (timer > waitTime)
        {
            //Put Ticket in hand
            if (tickets.Length > 0)
            {
                foreach (GameObject ticket in tickets)
                {
                    if (ticket.GetComponent<Ticket>().ticketState == Ticket.TicketState.Unpublished)
                    {
                        ticket.GetComponent<Ticket>().ticketState = Ticket.TicketState.BackLog;
                        break;
                    }
                }
            }

            scrumMaster.ticketPickedUp = false;
            anim.SetBool("isMovingTicket", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}
