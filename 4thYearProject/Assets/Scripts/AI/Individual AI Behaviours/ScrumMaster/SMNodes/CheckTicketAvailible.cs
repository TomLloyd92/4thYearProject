using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTicketAvailible : Node
{
    private ScrumMaster scrumMaster;
    bool ticketAvailible;

    GameObject[] tickets;

    public CheckTicketAvailible(ScrumMaster t_scrumMaster)
    {
        this.scrumMaster = t_scrumMaster;
        ticketAvailible = false;
    }

    public override state Evaluate()
    {

        tickets = GameObject.FindGameObjectsWithTag("Ticket");
        Debug.Log(tickets.Length);

        if (tickets.Length > 0)
        {
            foreach (GameObject ticket in tickets)
            {
                if (ticket.GetComponent<Ticket>().ticketState == Ticket.TicketState.Unpublished)
                {
                    ticketAvailible = true;
                    break;
                }
                else
                {
                    ticketAvailible = false;
                }
            }
        }


        if (ticketAvailible)
        {
            System.Array.Clear(tickets, 0, tickets.Length);
            ticketAvailible = false;
            return state.Failure;
        }
        else
        {
            System.Array.Clear(tickets, 0, tickets.Length);
            return state.Success;
        }
    }
}
