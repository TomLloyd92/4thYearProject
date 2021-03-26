using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCheckTicketNotNull : Node
{
    Developer dev;

    public DevCheckTicketNotNull(Developer t_dev)
    {
        dev = t_dev;
    }

    public override state Evaluate()
    {
        if(dev.currentTicket != null)
        {
           if(dev.currentTicket.ticketState == Ticket.TicketState.DevDone)
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
