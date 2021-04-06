using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlaceInRelease : Node
{
    Animator anim;
    Tester tester;
    KanBanBoard kanban;

    float timer = 0;
    float waitTime = 3;

    public TestPlaceInRelease(Tester tester, Animator t_anim, KanBanBoard kanban)
    {
        this.tester = tester;
        this.anim = t_anim;
        this.kanban = kanban;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Start Pick Up Ticket
        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;


        if (timer > waitTime)
        {
            tester.currentTicket.ticketState = Ticket.TicketState.Release;
            kanban.GetTesting().removeTicket(tester.currentTicket);
            anim.SetBool("isPlacingTicket", false);
            timer = 0;
            tester.hasTicket = false;
            tester.currentTicket = null;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}