using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPickUpTicketInDev : Node
{
    //Private Vars
    private Developer dev;
    private Animator anim;
    private HandPosition handPos;
    private InDev inDev;

    float timer = 0;
    float TIME_LIMIT = 3;


    public DevPickUpTicketInDev(Developer t_dev, Animator t_anim, HandPosition t_handPosition, InDev t_inDev)
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.handPos = t_handPosition;
        this.inDev = t_inDev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (dev.currentTicket.GetPickedUp())
        {
            return state.Success;
        }

        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;

        if (timer > TIME_LIMIT)
        {
            anim.SetBool("isPlacingTicket", false);
            dev.currentTicket.SetPickedUp(true, handPos);
            inDev.removeTicket(dev.currentTicket);
            timer = 0;
            return state.Success;
        }
        return state.Running;

    }
}
