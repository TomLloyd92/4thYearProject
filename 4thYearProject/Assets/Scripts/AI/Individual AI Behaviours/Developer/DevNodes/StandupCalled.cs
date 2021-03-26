using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandupCalled : Node
{
    bool standUp = false;

    public StandupCalled()
    {
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (standUp)
        {
            return state.Failure;
        }
        else
        {
            return state.Success;
        }
    }
}
