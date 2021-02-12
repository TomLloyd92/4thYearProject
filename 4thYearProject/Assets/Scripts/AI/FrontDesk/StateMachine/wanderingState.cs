using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wanderingState : State
{
    int currentPos = 0;

    public wanderingState(GameObject t_gameObject, Animator t_animator, Transform t_player, NavMeshAgent t_navMeshAgent, GameObject[] t_wanderingPos)
       : base(t_gameObject, t_animator, t_player, t_navMeshAgent,t_wanderingPos )
    {
        //Assign name
        name = STATE.WANDERING;

        //Set speed
        agent.speed = 2;
        agent.isStopped = false;
    }


    public override void Enter()
    {
        anim.SetTrigger("isWalking");
        agent.speed = 2;
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        float distance = Vector3.Distance(npc.transform.position, player.transform.position);


        if (distance < 2)
        {
            nextState = new idleState(npc, anim, player, agent, wanderPositions);
            stage = STATUS.EXIT;
        }
        else
        {
            //Wander to next position
            agent.SetDestination(wanderPositions[currentPos].transform.position);

            //Check if update position
            float distanceToWanderPos = Vector3.Distance(npc.transform.position, wanderPositions[currentPos].transform.position);

            if (distanceToWanderPos < 1)
            {
                if(currentPos < wanderPositions.Length - 1)
                {
                    currentPos++;
                }
                else
                {
                    currentPos = 0;
                }
            }
        }



    }

    public override void EXIT()
    {
        anim.ResetTrigger("isWalking");
        base.EXIT();
    }


}
