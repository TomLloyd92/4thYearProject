using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevMoveToTicket : Node
{
    //Private Vars
    private Developer dev;
    private float distance;
    private Ticket ticket;
    private float RANGE = 2;
    private Animator anim;
    private NavMeshAgent agent;


    public DevMoveToTicket(Developer t_dev, Animator t_anim, NavMeshAgent t_agent)
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.agent = t_agent;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        ticket = dev.currentTicket;

        //Evaluate Distance to player
        distance = Vector3.Distance(dev.transform.position, ticket.transform.position);

        //If not in range
        if (distance > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(ticket.transform.position);
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
