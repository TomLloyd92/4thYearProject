using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tester : MonoBehaviour
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
        TestStandUpCalled standupCalledNode = new TestStandUpCalled();

        //Assign Ticket
        TestHasTicket hasTicketNode = new TestHasTicket(this);
        TestMoveToBoard moveToBoardNode = new TestMoveToBoard(this, agent, anim);
        TestObserveBoard observeBoardNode = new TestObserveBoard(this, agent, anim, kanbanboard);
        TestAvailibleTicket availibleTicketNode = new TestAvailibleTicket(kanbanboard.testing);
        TestAssignTicket assignTicketNode = new TestAssignTicket(this, kanbanboard.testing);

        //Move Ticket Back - test failed -
        TestTicketInTest checkTicketInTestNode = new TestTicketInTest(this, kanbanboard.testing);
        TestMoveToTicket moveToTicketNode = new TestMoveToTicket(this, anim, agent);
        TestPickUpTicket pickUpTicketNode = new TestPickUpTicket(this, anim, handPos);
        TestMoveToInDev moveToInDevNode = new TestMoveToInDev(this, anim, agent, kanbanboard.inDev);
        TestPlaceInDev placeinDevNode = new TestPlaceInDev(this, anim, kanbanboard.testing);

        //Work
        TestTicketCompleted ticketCompletedNode = new TestTicketCompleted(this);
        TestMoveToPC moveToPCNode = new TestMoveToPC(this, anim, agent, PC);
        TestWorkPC workPCNode = new TestWorkPC(this, anim);

        //Move To Release
        TestCheckTicketNotNull ticketNotNull = new TestCheckTicketNotNull(this);
        TestMoveToRelease moveToReleaseNode = new TestMoveToRelease(this, anim, agent, kanbanboard.release);
        TestPlaceInRelease placeInRelease = new TestPlaceInRelease(this, anim, kanbanboard);



        //<---------END LEAF NODES---------->

        //<----------------- SELECTORS AND SEQENCERS -------------------> 
        //Stand Up
        Sequencer standUpSequence = new Sequencer(new List<Node> { hasTicketNode });

        //Assign Ticket
        Sequencer availibleTicketSequence = new Sequencer(new List<Node> { availibleTicketNode, assignTicketNode });

        //Board Moving Ticket
        //Selector pickUpTicketSelector = new Selector(new List<Node> { moveToTicketNode, pickUpTicketNode, moveToInDevNode, placeinDevNode });
        //Sequencer movingTicketSequencer = new Sequencer(new List<Node> { checkTicketInDevNode, pickUpTicketSelector });

        //Move Ticket
        Selector getTicketSelector = new Selector(new List<Node> { moveToBoardNode, observeBoardNode, availibleTicketSequence });
        Sequencer getTicketSequence = new Sequencer(new List<Node> { hasTicketNode, getTicketSelector });

        //Work On Ticket
        Selector workTicketSelector = new Selector(new List<Node> { moveToPCNode, workPCNode });
        Sequencer workTicketSequencer = new Sequencer(new List<Node> { ticketCompletedNode, workTicketSelector });

        //Move to Release
        //, , , 
        Selector moveToReleaseSelector = new Selector(new List<Node> { moveToBoardNode, pickUpTicketNode, moveToReleaseNode, placeInRelease });
        Sequencer moveToReleaseSequencer = new Sequencer(new List<Node> { ticketNotNull, moveToReleaseSelector });

        //<----------------- END SELECTORS AND SEQENCERS -------------------> 


        //HeadNode
        // , movingTicketSequencer, workTicketSequencer
        headNode = new Selector(new List<Node> { standUpSequence, getTicketSequence, workTicketSequencer, moveToReleaseSequencer });
    }
}
