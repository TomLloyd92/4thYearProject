using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAboutKanBan : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private Animator anim;
    private AudioSource talkKanBan;


    private bool playedAudio = false;
    private bool timerReached = false;
    float timer = 0;
    float waitTime = 10;

    public TalkAboutKanBan(ScrumMaster t_scrumMaster, Animator t_anim, AudioSource t_talkKanBan)
    {
        this.scrumMaster = t_scrumMaster;
        this.anim = t_anim;
        this.talkKanBan = t_talkKanBan;
    }

    public override state Evaluate()
    {
        Debug.Log("TALKING KAN BAN");
        //Start Idle animation
        anim.SetBool("isIdle", true);

        timer += Time.deltaTime;


        if (timer > waitTime)
        {
            anim.SetBool("isIdle", false);
            scrumMaster.standUpCompleted = true;
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
