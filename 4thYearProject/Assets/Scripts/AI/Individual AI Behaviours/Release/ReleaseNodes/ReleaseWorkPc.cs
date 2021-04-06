using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseWorkPc : Node
{
    //Private Vars for Move to player
    private ReleaseAI release;
    private Transform chair;
    private Animator anim;
    private GameObject ticket;
    private GameObject ticketSpawn;

    float timer = 0;
    const int waitTime = 5;

    public ReleaseWorkPc(ReleaseAI t_sm, Animator t_anim)
    {
        this.release = t_sm;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Rotate to look at board

        release.transform.rotation = Quaternion.Slerp(release.transform.rotation, Quaternion.identity, Time.deltaTime);


        //Start Shaking hand animation
        anim.SetBool("isWorking", true);

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            release.currentTicket.ticketState = Ticket.TicketState.ReleaseDone;
            anim.SetBool("isWorking", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
