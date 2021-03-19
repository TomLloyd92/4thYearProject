using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private NavMeshAgent agent;
    private Transform playerPos;
    private Animator anim;

    const int RANGE = 2;
 

    //Constructor, set Variables
    public MoveToPlayer(ScrumMaster t_sm, NavMeshAgent t_agent, Transform t_playerPos, Animator t_anim)
    {
        this.scrumMaster = t_sm;
        this.agent = t_agent;
        this.playerPos = t_playerPos;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
  
        //Evaluate Distance to player
        float distance = Vector3.Distance(scrumMaster.transform.position, playerPos.position);

        //If not in range
        if(distance > RANGE)
        {
            
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(playerPos.position);
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
