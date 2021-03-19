using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkAtPC : Node
{
    //Private Vars for Move to player
    private ScrumMaster scrumMaster;
    private NavMeshAgent agent;
    private Transform chair;
    private Animator anim;
    private GameObject ticket;
    private GameObject ticketSpawn;


    bool startedCoding;
    float timer = 0;
    const int waitTime = 5;

    public WorkAtPC(ScrumMaster t_sm, NavMeshAgent t_agent, Transform t_chair, Animator t_anim, GameObject t_ticket, GameObject t_ticketSpawn)
    {
        startedCoding = false;

        this.scrumMaster = t_sm;
        this.agent = t_agent;
        this.chair = t_chair;
        this.anim = t_anim;
        this.ticket = t_ticket;
        this.ticketSpawn = t_ticketSpawn;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //Start Shaking hand animation
        anim.SetBool("isCoding", true);

        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            scrumMaster.playerGreeted = true;
            anim.SetBool("isCoding", false);
            timer = 0;
            GameObject.Instantiate(ticket, ticketSpawn.transform.position , scrumMaster.transform.rotation);
            return state.Success;
        }

        //Return running
        return state.Running;

    }
}
