using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToInDev : Node
{
    //Private Vars
    private Developer dev;
    private float distance;
    private float RANGE = 3f;
    private Animator anim;
    private NavMeshAgent agent;
    private InDev inDev;



    public MoveToInDev(Developer t_dev, Animator t_anim, NavMeshAgent t_agent, InDev t_inDev )
    {
        this.dev = t_dev;
        this.anim = t_anim;
        this.agent = t_agent;
        this.inDev = t_inDev;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Evaluate Distance to player
        distance = Vector3.Distance(dev.transform.position, inDev.transform.position);

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
            //Debug.Log("WALKED TO IN DEV");
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            //In Range, Return Success
            return state.Success;
        }
    }
}
