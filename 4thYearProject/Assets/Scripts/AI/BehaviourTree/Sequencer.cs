using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sequencer Node (Inherit from node class)
public class Sequencer : Node
{
    //List of Nodes in the seqence
    protected List<Node> nodes;

    //Constructor
    public Sequencer(List<Node> t_nodes)
    {
        //Assign Nodes to this sequencer
        this.nodes = t_nodes;
    }

    public override state Evaluate()
    {

        bool isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case state.Running:
                    isAnyNodeRunning = true;
                    break;
                case state.Success:
                    break;
                case state.Failure:
                    currentState = state.Failure;
                    return currentState;
                default:
                    break;
            }
        }
        currentState = isAnyNodeRunning ? state.Running : state.Success;
        return currentState;

    }
}
