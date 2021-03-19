using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPC : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private NavMeshAgent agent;
    private Transform chair;
    private Animator anim;

    const float RANGE = 1.0f;


    //Constructor, set Variables
    public MoveToPC(ScrumMaster t_sm, NavMeshAgent t_agent, Transform t_chair, Animator t_anim)
    {
        this.scrumMaster = t_sm;
        this.agent = t_agent;
        this.chair = t_chair;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Evaluate Distance to player
        float distance = Vector3.Distance(scrumMaster.transform.position, chair.position);

        //If not in range
        if (distance > RANGE)
        {

            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(chair.position);
            //Return Running
            return state.Running;
        }
        else
        {
            Debug.Log("PC WALKING SUCCESS");

            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            //In Range, Return Success
            return state.Success;
        }

    }
}
