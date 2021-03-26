using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTicketCompleted : Node
{
    Developer dev;

    public DevTicketCompleted(Developer t_dev)
    {
        this.dev = t_dev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if(dev.currentTicket != null)
        {
            if (dev.currentTicket.ticketState != Ticket.TicketState.DevDone)
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