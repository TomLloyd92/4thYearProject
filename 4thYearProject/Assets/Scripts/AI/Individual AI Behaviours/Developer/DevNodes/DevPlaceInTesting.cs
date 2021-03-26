using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPlaceInTesting : Node
{
    Animator anim;
    Developer dev;
    Testing testing;

    float timer = 0;
    float waitTime = 3;

    public DevPlaceInTesting(Developer t_dev, Animator t_anim, Testing t_testing)
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.testing = t_testing;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Start Pick Up Ticket
        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;

        Debug.Log(timer);
        Debug.Log("PLACING TICKET NOW");

        if (timer > waitTime)
        {
            testing.removeTicket(dev.currentTicket);
            Debug.Log("Ticket Placed");
            dev.currentTicket.ticketState = Ticket.TicketState.Testing;
            anim.SetBool("isPlacingTicket", false);
            timer = 0;
            dev.hasTicket = false;
            dev.currentTicket = null;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}
