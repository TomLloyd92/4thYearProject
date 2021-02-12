using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class idleState : State
{
    AudioSource audio;

    //Constructor
    //Assign arguments to base class varibles
    public idleState(GameObject t_gameObject, Animator t_animator, Transform t_player, NavMeshAgent t_navMeshAgent, GameObject[] t_wanderPositions)
        : base (t_gameObject, t_animator, t_player, t_navMeshAgent, t_wanderPositions)
    {
        //Assign name
        name = STATE.IDLE;

        audio = t_gameObject.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        //Start the idle Animation
        anim.SetTrigger("isIdle");
        base.Enter();
        agent.speed = 0;
        audio.Play();
    }

    public override void Update()
    {
        base.Update();
        //Check distance between npc and player
        float distance = Vector3.Distance(npc.transform.position, player.transform.position);     

        npc.transform.LookAt(player.transform.position);


        //If distance is greater than zone 
        if ( distance > 4)
        {
            //Move to wandering
            nextState = new wanderingState(npc, anim, player, agent, wanderPositions);
            stage = STATUS.EXIT;
        }
        else
        {

        }

    }

    public override void EXIT()
    {
        //Resey the idle trigger
        anim.ResetTrigger("isIdle");
        base.EXIT();
    }
}
