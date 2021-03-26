using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailibleTicket : Node
{
    //Private Vars
    private Developer dev;
    private Backlog backlog;
    private List<Ticket> tickets;

    public AvailibleTicket(Developer t_dev, Backlog t_backlog)
    {
        this.backlog = t_backlog;
        this.dev = t_dev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        Debug.Log("EVALUATING AVAILIBLE TICKET");

        tickets = backlog.GetTickets();

        if (tickets.Count > 0 )
        {
             return state.Success;
        }
        else
        {
            return state.Failure;
        }
    }
}
