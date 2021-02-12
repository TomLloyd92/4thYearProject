using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sittingState : State
{
    AudioSource audio;

    //Constructor
    //Assign arguments to base class varibles
    public sittingState(GameObject t_gameObject, Animator t_animator, Transform t_player, NavMeshAgent t_navMeshAgent, GameObject[] t_wanderPositions)
        : base(t_gameObject, t_animator, t_player, t_navMeshAgent, t_wanderPositions)
    {
        //Assign name
        name = STATE.SITTING;
    }

    public override void Enter()
    {
        //Start the idle Animation
        anim.SetTrigger("isSitting");
        base.Enter();
        agent.speed = 0;
    }

    public override void Update()
    {
        base.Update();
        //Check distance between npc and player
        float distance = Vector3.Distance(npc.transform.position, player.transform.position);


        if (distance < 4)
        {
            nextState = new frontIdleState(npc, anim, player, agent, wanderPositions);
            stage = STATUS.EXIT;
        }



    }

    public override void EXIT()
    {
        //Resey the idle trigger
        anim.ResetTrigger("isSitting");
        base.EXIT();
    }
}
