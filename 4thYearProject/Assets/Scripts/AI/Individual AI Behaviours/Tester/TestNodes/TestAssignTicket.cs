using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAssignTicket : Node
{
    //Private Vars
    private Tester tester;
    private Testing testing;
    private List<Ticket> tickets;

    public TestAssignTicket(Tester t_test, Testing t_testing)
    {
        this.testing = t_testing;
        this.tester = t_test;
    }

    public override state Evaluate()
    {
        if (tester.currentTicket != null)
        {
            tester.hasTicket = true;
            return state.Success;
        }

        tickets = testing.GetTickets();

        foreach (Ticket ticket in tickets)
        {
            if(ticket.ticketState != Ticket.TicketState.CurrentlyTesting)
            {
                tester.currentTicket = ticket;
                tester.hasTicket = true;
                Debug.Log("Ticket Found and assigned");
                //Return running
                return state.Success;
            }
        }

        return state.Running;
    }
}
