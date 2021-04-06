using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCheckTicketNotNull : Node
{
    Tester tester;

    public TestCheckTicketNotNull(Tester tester)
    {
        this.tester = tester;
    }

    public override state Evaluate()
    {

        
        if (tester.currentTicket != null)
        {
            if (tester.currentTicket.ticketState == Ticket.TicketState.TestingDone)
            {
                Debug.Log("Testing Completed");

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
