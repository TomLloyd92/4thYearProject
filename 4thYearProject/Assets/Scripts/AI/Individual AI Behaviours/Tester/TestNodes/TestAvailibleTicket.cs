using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAvailibleTicket : Node
{
    //Private Vars
    private Testing testing;
    private List<Ticket> tickets;

    public TestAvailibleTicket(Testing t_testing)
    {
        this.testing = t_testing;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        tickets = testing.GetTickets();

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
