using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReleaseMoveToPc : Node
{
    //Private Vars
    private ReleaseAI release;
    private float distance;
    private float RANGE = 1f;
    private Animator anim;
    private NavMeshAgent agent;
    private GameObject PC;


    public ReleaseMoveToPc(ReleaseAI release, Animator t_anim, NavMeshAgent t_agent, GameObject t_pc)
    {
        this.release = release;
        this.anim = t_anim;
        this.agent = t_agent;
        this.PC = t_pc;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Evaluate Distance to player
        distance = Vector3.Distance(release.transform.position, PC.transform.position);



        //If not in range
        if (distance > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(PC.transform.position);
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
