using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCheckHasTicket : Node
{
    ReleaseAI release;

    public ReleaseCheckHasTicket(ReleaseAI t_release)
    {
        release = t_release;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Failure Does not need Ticket
        if (release.hasTicket)
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
