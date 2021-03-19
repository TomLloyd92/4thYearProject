using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base Node Class
[System.Serializable]
public abstract class Node
{
    //State of Node
    public enum state
    {
        None,
        Success,
        Failure,
        Running
    }

    //Current State + State type for Debugging
    public state currentState = state.None;

    public Node()
    {
        //Starting state set to none.
        currentState = state.None;

    }

    public abstract state Evaluate();


    //Get Function for current state
    public state getState()
    {
        return currentState;
    }

}
