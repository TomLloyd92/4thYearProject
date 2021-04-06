using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReleaseObserveBoard : Node
{
    //Private Vars
    private ReleaseAI release;
    private NavMeshAgent agent;
    private Animator anim;
    private KanBanBoard kanBanBoard;

    float timer;
    float waitTime = 5;


    public ReleaseObserveBoard(ReleaseAI t_release, NavMeshAgent t_agent, Animator t_anim, KanBanBoard t_board)
    {
        this.release = t_release;
        this.agent = t_agent;
        this.anim = t_anim;
        this.kanBanBoard = t_board;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (release.currentTicket != null)
        {
            return state.Failure;
        }

        //Rotate to look at board
        Vector3 targetPoint = new Vector3(kanBanBoard.transform.position.x, kanBanBoard.transform.position.y, kanBanBoard.transform.position.z) - release.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        release.transform.rotation = Quaternion.Slerp(release.transform.rotation, targetRotation, Time.deltaTime);


        //Start Pointing to board
        anim.SetBool("isIdle", true);
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            anim.SetBool("isIdle", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
