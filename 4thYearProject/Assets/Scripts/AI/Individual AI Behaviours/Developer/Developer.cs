using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Developer : MonoBehaviour
{
    private Selector headNode;
    private NavMeshAgent agent;
    private Animator anim;
    [SerializeField] KanBanBoard kanbanboard;
    [SerializeField] GameObject PC;

    public HandPosition handPos;

    public Ticket currentTicket = null;

    public bool hasTicket;

    private void Awake()
    {
        hasTicket = false;
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        createBT();
    }

    // Update is called once per frame
    void Update()
    {
        headNode.Evaluate();
    }

    private void createBT()
    {
        //<-------- LEAF NODES---------->
        //Actions
        //Stand Up
        StandupCalled standupCalledNode = new StandupCalled();

        //Assign Ticket
        HasTicket hasTicketNode = new HasTicket(this);
        MoveToBoard moveToBoardNode = new MoveToBoard(this, agent, anim);
        ObserveBoard observeBoardNode = new ObserveBoard(this, agent, anim, kanbanboard);
        AvailibleTicket availibleTicketNode = new AvailibleTicket(this, kanbanboard.backlog);
        DevAssignTicket devAssignTicketNode = new DevAssignTicket(this, kanbanboard.backlog);

        //Move Ticket
        DevCheckTicketInDev checkTicketInDevNode = new DevCheckTicketInDev(this, kanbanboard.inDev);
        DevMoveToTicket moveToTicketNode = new DevMoveToTicket(this, anim, agent);
        DevPickUpTicket pickUpTicketNode = new DevPickUpTicket(this, anim, handPos, kanbanboard.backlog);
        MoveToInDev moveToInDevNode = new MoveToInDev(this, anim, agent, kanbanboard.inDev);
        DevPlaceInDev placeinDevNode = new DevPlaceInDev(this, anim, kanbanboard.backlog);

        //Work
        DevTicketCompleted ticketCompletedNode = new DevTicketCompleted(this);
        DevMoveToPC moveToPCNode = new DevMoveToPC(this, anim, agent, PC);
        DevWorkPC workPCNode = new DevWorkPC(this, anim);

        //Move To Testing
        DevCheckTicketNotNull ticketNotNull = new DevCheckTicketNotNull(this);
        MoveToTesting moveToTestingNode = new MoveToTesting(this, anim, agent, kanbanboard.testing);
        DevPlaceInTesting placeInTesting = new DevPlaceInTesting(this, anim, kanbanboard.inDev);



        //<---------END LEAF NODES---------->

        //<----------------- SELECTORS AND SEQENCERS -------------------> 
        //Stand Up
        Sequencer standUpSequence = new Sequencer(new List<Node> { hasTicketNode });

        //Assign Ticket
        Sequencer availibleTicketSequence = new Sequencer(new List<Node> { availibleTicketNode, devAssignTicketNode });

        //Board Moving Ticket
        Selector pickUpTicketSelector = new Selector(new List<Node> { moveToTicketNode, pickUpTicketNode, moveToInDevNode, placeinDevNode  });
        Sequencer movingTicketSequencer = new Sequencer(new List<Node> { checkTicketInDevNode, pickUpTicketSelector });

        //Move Ticket
        Selector getTicketSelector = new Selector(new List<Node> { moveToBoardNode, observeBoardNode, availibleTicketSequence});
        Sequencer getTicketSequence = new Sequencer(new List<Node> { hasTicketNode, getTicketSelector });

        //Work On Ticket
        Selector workTicketSelector = new Selector(new List<Node> { moveToPCNode, workPCNode});
        Sequencer workTicketSequencer = new Sequencer(new List<Node> { ticketCompletedNode, workTicketSelector });

        //Move to testing
        Selector moveToTestingSelector = new Selector(new List<Node> { moveToTicketNode, pickUpTicketNode, moveToTestingNode,placeInTesting  });
        Sequencer moveToTestingSequencer = new Sequencer(new List<Node> { ticketNotNull, moveToTestingSelector });

        //<----------------- END SELECTORS AND SEQENCERS -------------------> 


        //HeadNode
        headNode = new Selector(new List<Node> { standUpSequence , getTicketSequence , movingTicketSequencer, workTicketSequencer, moveToTestingSequencer });
    }
}
