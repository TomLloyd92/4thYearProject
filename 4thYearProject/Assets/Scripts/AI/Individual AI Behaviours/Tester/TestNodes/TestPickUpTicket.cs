using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPickUpTicket : Node
{
    //Private Vars
    private Tester tester;
    private Animator anim;
    private HandPosition handPos;

    float timer = 0;
    float TIME_LIMIT = 3;


    public TestPickUpTicket(Tester t_tester, Animator t_anim, HandPosition t_handPosition)
    {
        this.tester = t_tester;
        this.anim = t_anim;
        this.handPos = t_handPosition;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        if (tester.currentTicket.GetPickedUp())
        {
            return state.Success;
        }

        anim.SetBool("isPlacingTicket", true);

        timer += Time.deltaTime;

        // Debug.Log(timer);

        if (timer > TIME_LIMIT)
        {
            Debug.Log("Ticket picked up");

            anim.SetBool("isPlacingTicket", false);
            tester.currentTicket.SetPickedUp(true, handPos);
            
            timer = 0;
            return state.Success;
        }
        return state.Running;

    }
}
