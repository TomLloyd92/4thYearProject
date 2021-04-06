using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPickUpTicket : Node
{
    //Private Vars
    private Developer dev;
    private Animator anim;
    private HandPosition handPos;
    private Backlog backlog;

    float timer = 0;
    float TIME_LIMIT = 3;


    public DevPickUpTicket(Developer t_dev, Animator t_anim, HandPosition t_handPosition, Backlog t_backlog)
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.handPos = t_handPosition;
        this.backlog = t_backlog;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if(dev.currentTicket.GetPickedUp())
        {
            return state.Success;
        }

        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;

       // Debug.Log(timer);

        if (timer > TIME_LIMIT)
        {
            anim.SetBool("isPlacingTicket", false);
            dev.currentTicket.SetPickedUp(true, handPos);
            timer = 0;
            return state.Success;
        }
        return state.Running;

    }
}
