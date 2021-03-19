using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTicket : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private NavMeshAgent agent;
    private Animator anim;

    private Vector3 ticketPos;

    private GameObject[] tickets;

    const float RANGE = 1.5f;

    float distance;

    public MoveToTicket(ScrumMaster t_sm, NavMeshAgent t_agent, Animator t_anim)
    {
        this.scrumMaster = t_sm;
        this.agent = t_agent;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        tickets = GameObject.FindGameObjectsWithTag("Ticket");

        if (tickets.Length > 0)
        {
            foreach (GameObject ticket in tickets)
            {
                if (ticket.GetComponent<Ticket>().ticketState == Ticket.TicketState.Unpublished)
                {
                    ticketPos = ticket.transform.position;
                    break;
                }
            }
        }

        //Evaluate Distance to player
        distance = Vector3.Distance(scrumMaster.transform.position, ticketPos);

        //If not in range
        if (distance > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(ticketPos);
            //Return Running
            return state.Running;
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            //In Range, Return Success
            return state.Success;
        }

    }
}
