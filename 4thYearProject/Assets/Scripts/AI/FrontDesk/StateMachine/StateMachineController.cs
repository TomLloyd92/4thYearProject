using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineController : MonoBehaviour
{
    public GameObject[] wayPoints;

    NavMeshAgent agent;
    Animator anim;
    public Transform player;
    State currentState;

    private void Start()
    {
        //Assign Varibles
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

        //Start in idle State
        currentState = new wanderingState(this.gameObject, anim , player, agent, wayPoints);
    }

    private void Update()
    {
        //Update State
        currentState = currentState.Process();
    }
}
