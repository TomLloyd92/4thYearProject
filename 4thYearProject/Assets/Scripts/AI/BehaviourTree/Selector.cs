using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sequencer Node (Inherit from node class)
public class Selector : Node
{
    //List of Nodes in the seqence
    protected List<Node> nodes = new List<Node>();

    //Constructor
    public Selector(List<Node> t_nodes)
    {
        //Assign Nodes to this sequencer
        this.nodes = t_nodes;
    }

    public override state Evaluate()
    {
        //Go through all nodes in the list
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case state.Running:
                    //Running on this node
                    currentState = state.Running;
                    return currentState;
                case state.Success:
                    //Break this node on success to move to next node
                    break;
                case state.Failure:
                    //break this node on failure to move to next node
                    break;
                default:
                    break;
            }
        }
        //If outside all nodes Selector was a failure as no node succeeded or ran.
        currentState = state.Failure;
        return currentState;
    }
}
