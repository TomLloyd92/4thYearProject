using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ReleaseAI : MonoBehaviour
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
        CreateBt();
    }

    // Update is called once per frame
    void Update()
    {
        headNode.Evaluate();
    }

    private void CreateBt()
    {
        //<-------- LEAF NODES---------->
        //Actions
        //Stand Up
        ReleaseStandUpCalled standupCalledNode = new ReleaseStandUpCalled();

        //Get Ticket
        ReleaseCheckHasTicket checkHasTicketNode = new ReleaseCheckHasTicket(this);
        ReleaseMoveToBoard moveToBoardNode = new ReleaseMoveToBoard(this, agent, anim);
        ReleaseObserveBoard releaseObserveBoardNode = new ReleaseObserveBoard(this, agent, anim, kanbanboard);
        ReleaseAvailibleTicket availibleTicketNode = new ReleaseAvailibleTicket(kanbanboard.GetRelease());
        ReleaseAssignTicket assignTicketNode = new ReleaseAssignTicket(this, kanbanboard.GetRelease());

        //Work on Ticket
        ReleaseCheckTicketComplete releaseCheckTicketCompleteNode = new ReleaseCheckTicketComplete(this);
        ReleaseMoveToPc moveToPcNode = new ReleaseMoveToPc(this, anim, agent, PC);
        ReleaseWorkPc workPcNode = new ReleaseWorkPc(this, anim);

        //Ticket in Done
        ReleaseTicketNotNull ticketNotNullNode = new ReleaseTicketNotNull(this);
        ReleasePlaceTicketInDone placeTicketInDoneNode = new ReleasePlaceTicketInDone(this, anim, kanbanboard); 

        //Sequencer
        //Stand up
        Sequencer releaseStandUpSequencer = new Sequencer(new List<Node> { standupCalledNode});

        //Get Ticket
        Sequencer assignTicketSequencer = new Sequencer(new List<Node> { availibleTicketNode, assignTicketNode});
        Selector availibleTicketSelector = new Selector(new List<Node> { moveToBoardNode, releaseObserveBoardNode, assignTicketSequencer });
        Sequencer availibleTicketSequencer = new Sequencer(new List<Node> { checkHasTicketNode, availibleTicketSelector});

        //Work on Ticket
        Selector workTicketSelector = new Selector(new List<Node> { moveToPcNode, workPcNode  });
        Sequencer checkTicketDoneSequencer = new Sequencer(new List<Node> { releaseCheckTicketCompleteNode, workTicketSelector });

        //Place on board
        Selector ticketDoneSelector = new Selector(new List<Node> { moveToBoardNode, placeTicketInDoneNode });
        Sequencer ticketNotNullSequencer = new Sequencer(new List<Node> { ticketNotNullNode, ticketDoneSelector });

        //HeadNode
        headNode = new Selector(new List<Node> { releaseStandUpSequencer, availibleTicketSequencer, checkTicketDoneSequencer, ticketNotNullSequencer });
    }
}
