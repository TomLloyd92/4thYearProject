using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStandUp : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;

    public CheckStandUp(ScrumMaster t_scrumMaster)
    {
        this.scrumMaster = t_scrumMaster;
    }

    public override state Evaluate()
    {
        //If the Standup has been completed return fail
        if (scrumMaster.standUpCompleted)
        {
            return state.Failure;
        }
        else
        {
            return state.Success;
        }
    }
}
