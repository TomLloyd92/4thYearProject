using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPlaceInDev : Node
{
    Animator anim;
    Developer dev;
    Backlog backlog;

    float timer = 0;
    float waitTime = 3;

    public DevPlaceInDev(Developer t_dev, Animator t_anim, Backlog t_backlog)
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.backlog = t_backlog;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Start Pick Up Ticket
        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;

        //Debug.Log("PLACING TICKET NOW");

        if (timer > waitTime)
        {
            backlog.removeTicket(dev.currentTicket.ID);
            //Debug.Log("Ticket Placed");
            dev.currentTicket.ticketState = Ticket.TicketState.InDev;
            anim.SetBool("isPlacingTicket", false);
            timer = 0;
            dev.hasTicket = true;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}
