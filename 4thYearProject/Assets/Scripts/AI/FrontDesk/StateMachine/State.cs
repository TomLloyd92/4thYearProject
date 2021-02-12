using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    //State Enum
    public enum STATE { IDLE, TALKING, SITTING, WANDERING };
    //Current Status of the state Enum
    public enum STATUS { ENTER, UPDATE, EXIT };

    //Varibles needed for the state
    public STATE name;
    protected STATUS stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;

    protected GameObject[] wanderPositions;


    public State(GameObject t_gameObject, Animator t_animator, Transform t_player, NavMeshAgent t_navMeshAgent, GameObject[] t_wanderPositions)
    {
        //Assign all
        npc = t_gameObject;
        anim = t_animator;
        player = t_player;
        agent = t_navMeshAgent;
        wanderPositions = t_wanderPositions;
        stage = STATUS.ENTER;
    }

    //Virtual Functions change Status
    public virtual void Enter() 
    { 
        stage = STATUS.UPDATE; 
    }
    public virtual void Update()
    { 
        stage = STATUS.UPDATE; 
    }
    public virtual void EXIT() 
    {
        stage = STATUS.EXIT; 

    }

    //Handler for the status
    public State Process()
    {
        if(stage == STATUS.ENTER)
        {
            Enter();
        }
        else if( stage == STATUS.UPDATE)
        {
            Update();
        }
        else if(stage == STATUS.EXIT)
        {
            EXIT();
            return nextState;
        }

        return this;
    }
}