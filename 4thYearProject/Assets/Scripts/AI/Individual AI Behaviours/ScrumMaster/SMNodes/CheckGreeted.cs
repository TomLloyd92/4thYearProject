using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGreeted : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;

    public CheckGreeted(ScrumMaster t_scrumMaster)
    {
        this.scrumMaster = t_scrumMaster;
    }

    public override state Evaluate()
    {
        //If the Player has been Greeted return fail
        if (scrumMaster.playerGreeted)
        {
            return state.Failure;
        }
        else
        {
            return state.Success;
        }
    }
}
