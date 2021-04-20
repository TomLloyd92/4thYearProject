using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlaceInDev : Node
{
    Animator anim;
    Tester tester;
    Testing testing;

    float timer = 0;
    float waitTime = 3;

    public TestPlaceInDev(Tester t_tester, Animator t_anim, Testing t_testing)
    {
        this.tester = t_tester;
        this.anim = t_anim;
        this.testing = t_testing;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Start Pick Up Ticket
        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            testing.removeTicket(tester.currentTicket);
            tester.currentTicket.ticketState = Ticket.TicketState.InDev;
            anim.SetBool("isPlacingTicket", false);
            timer = 0;
            tester.currentTicket = null;
            tester.hasTicket = false;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}
