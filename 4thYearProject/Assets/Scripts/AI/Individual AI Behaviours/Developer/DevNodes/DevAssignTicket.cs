using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevAssignTicket : Node
{
    //Private Vars
    private Developer dev;
    private Backlog backlog;
    private List<Ticket> tickets;

    public DevAssignTicket(Developer t_dev, Backlog t_backlog)
    {
        this.backlog = t_backlog;
        this.dev = t_dev;
    }

    public override state Evaluate()
    {
        if(dev.currentTicket != null)
        {
            return state.Success;
        }

        tickets = backlog.GetTickets();

        foreach (Ticket ticket in tickets)
        {
            if (!ticket.GetPickedUp())
            {
                dev.currentTicket = ticket;
                Debug.Log("Ticket Found and assigned");
                //Return running
                return state.Success;
            }
        }

        return state.Running;
    }  
}
