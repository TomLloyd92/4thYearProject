using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCheckTicketComplete : Node
{
    ReleaseAI release;

    public ReleaseCheckTicketComplete(ReleaseAI release)
    {
        this.release = release;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (release.currentTicket != null)
        {
            if (release.currentTicket.ticketState != Ticket.TicketState.ReleaseDone)
            {
                return state.Success;
            }
            else
            {
                return state.Failure;
            }
        }

        return state.Failure;
    }
}
