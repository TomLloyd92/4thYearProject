using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTicketCompleted : Node
{
    Tester tester;

    public TestTicketCompleted(Tester t_tester)
    {
        this.tester = t_tester;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (tester.currentTicket != null)
        {
            if (tester.currentTicket.ticketState != Ticket.TicketState.TestingDone)
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
