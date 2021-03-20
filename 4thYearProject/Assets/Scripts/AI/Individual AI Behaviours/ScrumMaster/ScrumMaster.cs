using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScrumMaster : MonoBehaviour
{
    public Transform playerTransform;
    public Transform kanBanBoardPos;
    public Transform kanBanBoard;
    public Transform chair;
    public AudioSource greeting;
    public AudioSource kanBanTalk;
    public GameObject ticket;
    public GameObject ticketSpawnPoint;
    public Transform handPos;
    public HandPosition handPosition;

    NavMeshAgent agent;
    Animator anim;

    //Bools
    public bool playerGreeted;
    public bool standUpCompleted;
    public bool ticketPickedUp;



    Selector headNode;

    private void Awake()
    {
        //Initialise Variables on awake
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        playerGreeted = false;
        standUpCompleted = false;
        ticketPickedUp = false;


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
        //<----------------- Leaf Nodes ------------------->
        //Actions
        //Greeting Actions
        CheckGreeted checkGreetedNode = new CheckGreeted(this);
        MoveToPlayer moveToPlayerNode = new MoveToPlayer(this, agent, playerTransform, anim);
        GreetPlayer greetPlayerNode = new GreetPlayer(this, anim, greeting);

        //Stand up Actions
        CheckStandUp checkStandUpNode = new CheckStandUp(this);
        WalkToKanBan walkToKanBanNode = new WalkToKanBan(this, agent, kanBanBoardPos, anim);
        CallStandUp callStandUpNode = new CallStandUp(this, anim, kanBanBoard);
        WaitForTeam waitForTeamNode = new WaitForTeam(this, anim);
        TalkAboutKanBan talkAboutKanBanNode = new TalkAboutKanBan(this, anim, kanBanTalk);

        //Create Ticket Actions
        CheckTicketAvailible checkTicketAvailibleNode = new CheckTicketAvailible(this);
        MoveToPC moveToPCNode = new MoveToPC(this, agent, chair, anim );
        WorkAtPC workAtPCNode = new WorkAtPC(this, agent, chair, anim, ticket, ticketSpawnPoint);

        //Place Ticket on Kan Ban Actions
        CheckAvailibleTicket availibleTicketNode = new CheckAvailibleTicket();
        MoveToTicket moveToTicketNode = new MoveToTicket(this, agent, anim );
        PickUpTicket pickUpTicketNode = new PickUpTicket(this, anim, handPosition);
        PlaceTicketOnBoard placeTicketOnBoardNode = new PlaceTicketOnBoard(this, anim);

        //<----------------- END Leaf Nodes ------------------->

        //<----------------- Selector and Sequencers -------------------> 
        //Greetings
        Selector greetPlayerSelector = new Selector(new List<Node> { moveToPlayerNode, greetPlayerNode });
        Sequencer greetSequence = new Sequencer(new List<Node> { checkGreetedNode, greetPlayerSelector });

        //Morning Stand Up
        Selector standUpSelector = new Selector(new List<Node> { walkToKanBanNode, callStandUpNode, waitForTeamNode, talkAboutKanBanNode });
        Sequencer kanBanSeqence = new Sequencer(new List<Node> { checkStandUpNode, standUpSelector });

        //Creating Ticket / Programming
        Selector makeTicketSelector = new Selector(new List<Node> { moveToPCNode , workAtPCNode });
        Sequencer makeTicketSequence = new Sequencer(new List<Node> { checkTicketAvailibleNode, makeTicketSelector });

        //Place Ticket on Kan Ban
        //Sequencer
        Selector placeTicketSelector = new Selector(new List<Node> { moveToTicketNode, pickUpTicketNode, walkToKanBanNode, placeTicketOnBoardNode });
        Sequencer placeTicketSequencer = new Sequencer(new List<Node> { availibleTicketNode, placeTicketSelector});

        //Work Selector
        Selector workSelector = new Selector(new List<Node> { kanBanSeqence, makeTicketSequence, placeTicketSequencer });
        //<----------------- END Selector and Sequencers ------------------->


        //HeadNode Set
        headNode = new Selector(new List<Node> { greetSequence, workSelector });
    }




}
