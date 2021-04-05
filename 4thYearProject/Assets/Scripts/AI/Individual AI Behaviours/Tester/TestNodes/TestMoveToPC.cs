using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveToPC : Node
{
    //Private Vars
    private Tester tester;
    private float distance;
    private float RANGE = 1f;
    private Animator anim;
    private NavMeshAgent agent;
    private GameObject PC;


    public TestMoveToPC(Tester tester, Animator t_anim, NavMeshAgent t_agent, GameObject t_pc)
    {
        this.tester = tester;
        this.anim = t_anim;
        this.agent = t_agent;
        this.PC = t_pc;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {

        //Evaluate Distance to player
        distance = Vector3.Distance(tester.transform.position, PC.transform.position);



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
