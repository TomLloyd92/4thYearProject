using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveToRelease : Node
{
    //Private Vars
    private Tester tester;
    private float distance;
    private float RANGE = 4f;
    private Animator anim;
    private NavMeshAgent agent;
    private Release release;



    public TestMoveToRelease(Tester tester, Animator t_anim, NavMeshAgent t_agent, Release release)
    {
        this.tester = tester;
        this.anim = t_anim;
        this.agent = t_agent;
        this.release = release;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Evaluate Distance to player
        distance = Vector3.Distance(tester.transform.position, release.transform.position);

        //If not in range
        if (distance > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for player
            agent.isStopped = false;
            agent.SetDestination(release.transform.position);
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
