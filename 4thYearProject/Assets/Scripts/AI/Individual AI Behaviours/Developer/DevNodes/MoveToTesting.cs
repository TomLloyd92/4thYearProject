using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTesting : Node
{
    //Private Vars
    private Developer dev;
    private float distance;
    private float RANGE = 3f;
    private Animator anim;
    private NavMeshAgent agent;
    private Testing testing;



    public MoveToTesting(Developer t_dev, Animator t_anim, NavMeshAgent t_agent, Testing t_testing)
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.agent = t_agent;
        this.testing = t_testing;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Evaluate Distance to player
        distance = Vector3.Distance(dev.transform.position, testing.transform.position);

        //If not in range
        if (distance > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(testing.transform.position);
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
