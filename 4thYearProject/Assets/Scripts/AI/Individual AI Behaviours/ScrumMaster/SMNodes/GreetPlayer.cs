using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreetPlayer : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private Animator anim;
    private AudioSource greeting;


    private bool playedAudio = false;
    private bool timerReached = false;
    float timer = 0;
    float waitTime = 10;

    public GreetPlayer(ScrumMaster t_scrumMaster, Animator t_anim, AudioSource t_greeting)
    {
        this.scrumMaster = t_scrumMaster;
        this.anim = t_anim;
        this.greeting = t_greeting;
    }

    public override state Evaluate()
    {

        if(!playedAudio)
        {
            greeting.Play();
            playedAudio = true;
        }

        //If the Player has been Greeted return fail
        if (scrumMaster.playerGreeted)
        {
            return state.Failure;
        }
        else
        {
   
            //Start Shaking hand animation
            anim.SetBool("isShakingHand", true);


            timer += Time.deltaTime;


            if (timer > waitTime)
            {
                scrumMaster.playerGreeted = true;
                anim.SetBool("isShakingHand", false);
                return state.Success;
            }

            //Return running
            return state.Running;
        }
    }

}
