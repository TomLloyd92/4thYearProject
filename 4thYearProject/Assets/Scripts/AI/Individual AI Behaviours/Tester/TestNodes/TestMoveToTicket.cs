using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveToTicket : Node
{
    //Private Vars
    private Tester tester;
    private float distance;
    private Ticket ticket;
    private float RANGE = 2;
    private Animator anim;
    private NavMeshAgent agent;


    public TestMoveToTicket(Tester t_test, Animator t_anim, NavMeshAgent t_agent)
    {
        this.tester = t_test;
        this.anim = t_anim;
        this.agent = t_agent;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        ticket = tester.currentTicket;

        //Evaluate Distance to player
        distance = Vector3.Distance(tester.transform.position, ticket.transform.position);

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
