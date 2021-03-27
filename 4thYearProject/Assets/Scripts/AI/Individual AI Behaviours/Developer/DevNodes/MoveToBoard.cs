using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToBoard : Node
{
    //Private Vars
    private Developer developer;
    private NavMeshAgent agent;
    private Animator anim;

    private Vector3 freePos;

    private KanBanMeetingPoints meetingPoints;
    private MeetingPoint[] meetingPoint;

    int positionNumber = -1;

    float distanceToPositions = 100000;
    const float RANGE = 1;

    public MoveToBoard(Developer t_dev, NavMeshAgent t_agent, Animator t_anim)
    {
        this.developer = t_dev;
        this.agent = t_agent;
        this.anim = t_anim;
    }

    //Evaluate node, return state
    public override state Evaluate()
    {
        //General Meeting area
        meetingPoints = GameObject.FindGameObjectWithTag("MeetingPoints").GetComponent<KanBanMeetingPoints>();

        //Get Meeting Points
        meetingPoint = meetingPoints.meetingPoints;

        for(int i = 0; i < meetingPoint.Length; i++)
        {
            if (!meetingPoint[i].spotTaken)
            {
                distanceToPositions = Vector3.Distance(developer.transform.position, meetingPoint[i].transform.position);
                freePos = meetingPoint[i].transform.position;
                positionNumber = i;
                break;
            }
            else
            {
                //Do nothing

            }
        }
    

        //If not in range
        if (distanceToPositions > RANGE)
        {
            //Set Animation
            anim.SetBool("isWalking", true);

            //Set destination for Board Pos
            agent.isStopped = false;
            agent.SetDestination(freePos);
            //Return Running
            return state.Running;
        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);

            //Set Position to taken
            meetingPoint[positionNumber].takeSpot();

            //In Range, Return Success
            return state.Success;
        }

    }
}
