using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseTicketNotNull : Node
{
    ReleaseAI release;

    public ReleaseTicketNotNull(ReleaseAI release)
    {
        this.release = release;
    }

    public override state Evaluate()
    {

        if (release.currentTicket != null)
        {
            if (release.currentTicket.ticketState == Ticket.TicketState.ReleaseDone)
            {
                Debug.Log("Release Completed");

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
