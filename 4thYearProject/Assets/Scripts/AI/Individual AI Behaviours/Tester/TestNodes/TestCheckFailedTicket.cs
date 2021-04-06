using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheckFailedTicket : Node
{
    Tester tester;

    public TestCheckFailedTicket(Tester t_tester)
    {
        this.tester = t_tester;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (tester.currentTicket != null)
        {
            if (tester.currentTicket.ticketState == Ticket.TicketState.TestingFailed)
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
