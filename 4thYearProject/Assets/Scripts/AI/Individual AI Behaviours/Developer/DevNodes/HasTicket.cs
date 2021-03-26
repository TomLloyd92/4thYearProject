using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTicket : Node
{
    Developer dev;

    public HasTicket(Developer t_dev)
    {
        dev = t_dev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Failure Does not need Ticket
        if (dev.hasTicket)
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
