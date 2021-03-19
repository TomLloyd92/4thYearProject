using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForTeam : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private Animator anim;


    private bool playedAudio = false;
    private bool timerReached = false;
    float timer = 0;
    float waitTime = 5;

    public WaitForTeam(ScrumMaster t_scrumMaster, Animator t_anim)
    {
        this.scrumMaster = t_scrumMaster;
        this.anim = t_anim;
    }

    public override state Evaluate()
    {
        Debug.Log("WAITING FOR TEAM");
        //Start Idle animation
        anim.SetBool("isIdle", true);

        timer += Time.deltaTime;


        if (timer > waitTime)
        {
            Debug.Log("WAIT FOR TEAM SUCCESS");

            anim.SetBool("isIdle", false);
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
