using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTicketInTest : Node
{
    //Private Vars
    private Tester tester;
    private Testing inTesting;

    public TestTicketInTest(Tester t_tester, Testing t_inTesting)
    {
        this.tester = t_tester;
        this.inTesting = t_inTesting;

    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        foreach (Ticket ticket in inTesting.GetTickets())
        {
            if (ticket.ID == tester.currentTicket.ID)
            {
                //Ticket already in no need to move it
                return state.Failure;
            }
        }

        //Ticket does need to be moved
        return state.Success;
    }
}
