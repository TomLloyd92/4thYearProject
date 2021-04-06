using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseAssignTicket : Node
{
    //Private Vars
    private ReleaseAI releaseAI;
    private Release release;
    private List<Ticket> tickets;

    public ReleaseAssignTicket(ReleaseAI releaseAI, Release release)
    {
        this.release = release;
        this.releaseAI = releaseAI;
    }

    public override state Evaluate()
    {
        if (releaseAI.currentTicket != null)
        {
            return state.Success;
        }

        tickets = release.GetTickets();

        foreach (Ticket ticket in tickets)
        {
            if (ticket.ticketState != Ticket.TicketState.ReleaseDone)
            {
                releaseAI.currentTicket = ticket;
                releaseAI.hasTicket = true;
                //Return running
                return state.Success;
            }
        }

        return state.Running;
    }
}
