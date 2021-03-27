using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStandUpCalled : Node
{
    bool standUp = false;

    public TestStandUpCalled()
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