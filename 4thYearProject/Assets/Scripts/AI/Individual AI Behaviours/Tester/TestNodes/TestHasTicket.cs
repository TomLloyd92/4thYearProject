using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHasTicket : Node
{
    Tester tester;

    public TestHasTicket(Tester t_dev)
    {
        tester = t_dev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Failure Does not need Ticket
        if (tester.hasTicket)
        {
            return state.Failure;
        }
        //Needs to pick up a ticket
        else
        {
            return state.Success;
        }
    }
}
