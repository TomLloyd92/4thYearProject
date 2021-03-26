using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObserveBoard : Node
{
    //Private Vars
    private Developer developer;
    private NavMeshAgent agent;
    private Animator anim;
    private KanBanBoard kanBanBoard;

    float timer;
    float waitTime = 5;


    public ObserveBoard(Developer t_dev, NavMeshAgent t_agent, Animator t_anim, KanBanBoard t_board)
    {
        this.developer = t_dev;
        this.agent = t_agent;
        this.anim = t_anim;
        this.kanBanBoard = t_board;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if(developer.currentTicket !=null)
        {
            return state.Failure;
        }

        //Rotate to look at board
        Vector3 targetPoint = new Vector3(kanBanBoard.transform.position.x, kanBanBoard.transform.position.y, kanBanBoard.transform.position.z) - developer.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        developer.transform.rotation = Quaternion.Slerp(developer.transform.rotation, targetRotation, Time.deltaTime);


        //Start Pointing to board
        anim.SetBool("isObserving", true);
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            anim.SetBool("isObserving", false);
            timer = 0;
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}