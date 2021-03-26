using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCheckTicketInDev : Node
{
    //Private Vars
    private Developer dev;
    private InDev inDev;

    public DevCheckTicketInDev(Developer t_dev, InDev t_inDev)
    {
        this.dev = t_dev;
        this.inDev = t_inDev;

    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        foreach(Ticket ticket in inDev.GetTickets())
        {
            if(ticket.ID == dev.currentTicket.ID)
            {
                //Ticket already in no need to move it
                return state.Failure;
            }
        }

        //Ticket does need to be moved
        return state.Success;
    }

}
