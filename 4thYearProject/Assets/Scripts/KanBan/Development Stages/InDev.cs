using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDev : MonoBehaviour
{
    public List<Ticket> tickets = new List<Ticket>();
    [SerializeField] private Transform[] spaces;

    public List<Ticket> GetTickets()
    {
        return tickets;
    }

    #region VR
    private void OnTriggerEnter(Collider collider)
    {
        if (Player.instance.playerRole == Player.PlayerRole.Developer)
        {
            if (collider.tag == "Ticket")
            {
                tickets.Add(collider.GetComponent<Ticket>());
                collider.GetComponent<Ticket>().freezeTicket();
                Player.instance.currentTicket = collider.GetComponent<Ticket>();
            }
        }
        else if(Player.instance.playerRole == Player.PlayerRole.Tester && collider.GetComponent<Ticket>().ticketState == Ticket.TicketState.TestingFailed)
        {
            if (collider.tag == "Ticket")
            {
                tickets.Add(collider.GetComponent<Ticket>());
                collider.GetComponent<Ticket>().freezeTicket();
                collider.GetComponent<Ticket>().ticketState = Ticket.TicketState.InDev;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Ticket")
        {
            collider.GetComponent<Ticket>().unfreezeTicket();

            //Remove the ticket on exit if player is developer
            if(Player.instance.playerRole == Player.PlayerRole.Developer)
            {
                removeTicket(collider.GetComponent<Ticket>());
            }
        }
    }
    #endregion

    public void addTicket(Ticket t_ticket)
    {
        tickets.Add(t_ticket);

        t_ticket.SetOnBoard(spaces[tickets.Count - 1].position);
    }
    public void removeTicket(Ticket t_ticket)
    {
        tickets.Remove(t_ticket);
    }

    private void updateTicketPos()
    {
        foreach (Ticket ticket in tickets)
        {
            ticket.SetOnBoard(this.transform.position);
        }
    }
}
