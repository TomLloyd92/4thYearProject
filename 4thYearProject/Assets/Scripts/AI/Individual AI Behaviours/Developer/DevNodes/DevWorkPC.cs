using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevWorkPC : Node
{
    //Private Vars for Move to player
    private Developer dev;
    private Transform chair;
    private Animator anim;
    private GameObject ticket;
    private GameObject ticketSpawn;

    float timer = 0;
    const int waitTime = 5;

    public DevWorkPC(Developer t_sm, Animator t_anim)
    {
        this.dev = t_sm;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Rotate to look at board
   
        dev.transform.rotation = Quaternion.Slerp(dev.transform.rotation, Quaternion.identity, Time.deltaTime);


        //Start Shaking hand animation
        anim.SetBool("isWorking", true);

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            dev.currentTicket.ticketState = Ticket.TicketState.DevDone;
            anim.SetBool("isWorking", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
