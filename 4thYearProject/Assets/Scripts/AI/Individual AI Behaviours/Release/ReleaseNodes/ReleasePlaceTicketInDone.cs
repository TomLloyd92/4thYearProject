using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ReleasePlaceTicketInDone : Node
{
    Animator anim;
    ReleaseAI release;
    KanBanBoard kanban;

    float timer = 0;
    float waitTime = 3;

    public ReleasePlaceTicketInDone(ReleaseAI release, Animator t_anim, KanBanBoard kanban)
    {
        this.release = release;
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
            release.currentTicket.ticketState = Ticket.TicketState.Done;
            kanban.GetRelease().removeTicket(release.currentTicket);
            anim.SetBool("isPlacingTicket", false);
            timer = 0;
            release.hasTicket = false;
            release.currentTicket = null;
            return state.Success;
        }

        //Return running
        return state.Running;
    }
}
