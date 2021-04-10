using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class frontIdleState : State
{
    AudioSource audio;
    Canvas infoCanvas;

    //Constructor
    //Assign arguments to base class varibles
    public frontIdleState(GameObject t_gameObject, Animator t_animator, Transform t_player, NavMeshAgent t_navMeshAgent, GameObject[] t_wanderPositions)
        : base(t_gameObject, t_animator, t_player, t_navMeshAgent, t_wanderPositions)
    {
        //Assign name
        name = STATE.IDLE;

        audio = t_gameObject.GetComponent<AudioSource>();
    }

    public override void Enter()
    {
        infoCanvas = GameObject.FindGameObjectWithTag("MainMenuUi").GetComponent<Canvas>();

        //Start the idle Animation
        anim.SetTrigger("isIdle");
        base.Enter();
        audio.Play();
        infoCanvas.enabled = true;
        //agent.speed = 0;
    }

    public override void Update()
    {
        base.Update();


        //Check distance between npc and player
        float distance = Vector3.Distance(npc.transform.position, player.transform.position);

        npc.transform.LookAt(player.transform.position);


        //If distance is greater than zone 
        if (distance > 4)
        {
            //Move to wandering
            nextState = new sittingState(npc, anim, player, agent, wanderPositions);
            stage = STATUS.EXIT;
        }
        else
        {

        }

    }

    public override void EXIT()
    {
        //Resey the idle trigger
        infoCanvas.enabled = false;
        anim.ResetTrigger("isIdle");
        base.EXIT();
    }
}
