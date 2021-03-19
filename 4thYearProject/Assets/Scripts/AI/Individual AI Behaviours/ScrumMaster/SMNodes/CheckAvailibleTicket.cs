using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAvailibleTicket : Node
{
    bool ticketAvailible;
    GameObject[] tickets;



    public CheckAvailibleTicket()
    {
        ticketAvailible = false;
    }

    public override state Evaluate()
    {
        tickets = GameObject.FindGameObjectsWithTag("Ticket");

        if (tickets.Length > 0)
        {
            foreach (GameObject ticket in tickets)
            {
                if (ticket.GetComponent<Ticket>().ticketState == Ticket.TicketState.Unpublished)
                {
                    ticketAvailible = true;
                    break;
                }
            }
        }

        if (ticketAvailible)
        {
            ticketAvailible = false;
            return state.Success;
        }
        else
        {
            return state.Failure;
        }
    }
}
