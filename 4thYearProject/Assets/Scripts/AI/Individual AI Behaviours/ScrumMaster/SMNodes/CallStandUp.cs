using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CallStandUp : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private Transform kanBanBoard;
    private Animator anim;


    float timer = 0;
    float waitTime = 5;
    const int RANGE = 2;

    public CallStandUp(ScrumMaster t_sm, Animator t_anim, Transform t_kanBanBoard)
    {
        this.scrumMaster = t_sm;
        this.anim = t_anim;
        this.kanBanBoard = t_kanBanBoard;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Rotate to look at board
        Vector3 targetPoint = new Vector3(kanBanBoard.transform.position.x, kanBanBoard.position.y, kanBanBoard.transform.position.z) - scrumMaster.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);        
        scrumMaster.transform.rotation = Quaternion.Slerp(scrumMaster.transform.rotation, targetRotation, Time.deltaTime);



        //If the Player has been Greeted return fail
        if (scrumMaster.standUpCompleted)
        {
            return state.Failure;
        }
        else
        {
            //Start Pointing to board
            anim.SetBool("isPointing", true);
            timer += Time.deltaTime;


            if (timer > waitTime)
            {
                //scrumMaster.playerGreeted = true;
                anim.SetBool("isPointing", false);
                return state.Success;
            }


            //Return running
            return state.Running;
        }

    }
}
