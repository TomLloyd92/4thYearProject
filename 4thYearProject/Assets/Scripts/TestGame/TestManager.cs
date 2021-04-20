using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI thetext;
    static int currentTicket = 0;
    GameObject[] tickets;

    public void Awake()
    {
        updateText();
    }

    public void testCurrentTicket()
    {
        tickets = GameObject.FindGameObjectsWithTag("Ticket");

        if(tickets == null)
        {
            thetext.text = "No Current Tickets in Test";
        }

        foreach(GameObject ticket in tickets)
        {
            if(ticket.GetComponent<Ticket>().ID == currentTicket && ticket.GetComponent<Ticket>().ticketState == Ticket.TicketState.Testing)
            {
                int success = Random.Range(100, 0);
                if(success > 50)
                {
                    ticket.GetComponent<Ticket>().ticketState = Ticket.TicketState.TestingDone;
                    thetext.text = "PASSED!";
                    Debug.Log("Player Test Passed");
                    break;
                }
                else
                {
                    ticket.GetComponent<Ticket>().ticketState = Ticket.TicketState.TestingFailed;
                    thetext.text = "FAILED!";
                    Debug.Log("Player Test Failed");
                    break;
                }
            }
            else
            {
                thetext.text = "F";//"The current Ticket you are trying to Test is not in Testing, Please check the Kanban Board for a viable Ticket";
            }
        }




    }

    public void currentTicketUp()
    {
        currentTicket += 1;
        updateText();
    }
    public void currentTicketDown()
    {
        currentTicket -= 1;
        updateText();
    }

    private void updateText()
    {
        thetext.text = currentTicket.ToString();
    }
}
