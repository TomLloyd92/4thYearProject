using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWorkPC : Node
{
    //Private Vars for Move to player
    private Tester tester;
    private Transform chair;
    private Animator anim;
    private GameObject ticket;
    private GameObject ticketSpawn;

    float timer = 0;
    const int waitTime = 5;

    public TestWorkPC(Tester tester, Animator t_anim)
    {
        this.tester = tester;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
 

        //Rotate to look at board
        tester.transform.rotation = Quaternion.Slerp(tester.transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);


        //Start Shaking hand animation
        anim.SetBool("isWorking", true);

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            int success = Random.Range(100, 0);
            if (success < 50)
            {
                Debug.Log("Test Failed");
                tester.currentTicket.ticketState = Ticket.TicketState.TestingFailed;
                anim.SetBool("isWorking", false);
                timer = 0;
                return state.Success;
            }
            else
            {
                Debug.Log("Test Succeded");
                tester.currentTicket.ticketState = Ticket.TicketState.TestingDone;
                anim.SetBool("isWorking", false);
                timer = 0;
                return state.Success;
            }
        }

        //Return running
        return state.Running;

    }
}
