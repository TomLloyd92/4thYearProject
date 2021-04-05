using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveToInDev : Node
{
    //Private Vars
    private Tester tester;
    private float distance;
    private float RANGE = 3f;
    private Animator anim;
    private NavMeshAgent agent;
    private InDev inDev;



    public TestMoveToInDev(Tester t_tester, Animator t_anim, NavMeshAgent t_agent, InDev t_inDev)
    {
        this.tester = t_tester;
        this.anim = t_anim;
        this.agent = t_agent;
        this.inDev = t_inDev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Evaluate Distance to player
        distance = Vector3.Distance(tester.transform.position, inDev.transform.position);

        //If not in range
        if (distance > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(inDev.transform.position);
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
