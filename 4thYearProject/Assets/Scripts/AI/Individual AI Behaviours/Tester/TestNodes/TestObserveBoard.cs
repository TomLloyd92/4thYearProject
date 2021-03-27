using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestObserveBoard : Node
{
    //Private Vars
    private Tester tester;
    private NavMeshAgent agent;
    private Animator anim;
    private KanBanBoard kanBanBoard;

    float timer;
    float waitTime = 5;


    public TestObserveBoard(Tester t_test, NavMeshAgent t_agent, Animator t_anim, KanBanBoard t_board)
    {
        this.tester = t_test;
        this.agent = t_agent;
        this.anim = t_anim;
        this.kanBanBoard = t_board;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (tester.currentTicket != null)
        {
            return state.Failure;
        }

        //Rotate to look at board
        Vector3 targetPoint = new Vector3(kanBanBoard.transform.position.x, kanBanBoard.transform.position.y, kanBanBoard.transform.position.z) - tester.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        tester.transform.rotation = Quaternion.Slerp(tester.transform.rotation, targetRotation, Time.deltaTime);


        //Start Pointing to board
        anim.SetBool("isLooking", true);
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            anim.SetBool("isLooking", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
