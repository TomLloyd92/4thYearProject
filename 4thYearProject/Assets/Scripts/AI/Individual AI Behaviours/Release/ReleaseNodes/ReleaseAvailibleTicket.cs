using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseAvailibleTicket : Node
{
    //Private Vars
    private Release release;
    private List<Ticket> tickets;

    public ReleaseAvailibleTicket(Release t_release)
    {
        this.release = t_release;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        tickets = release.GetTickets();

        if (tickets.Count > 0)
        {
            return state.Success;
        }
        else
        {
            return state.Failure;
        }
    }
}
