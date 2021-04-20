using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done : MonoBehaviour
{
    public List<Ticket> tickets = new List<Ticket>();
    [SerializeField] Transform[] spaces;

    public List<Ticket> GetTickets()
    {
        return tickets;
    }

    #region VR
    private void OnTriggerEnter(Collider collider)
    {
        if (Player.instance.playerRole == Player.PlayerRole.Release)
        {
            if (collider.tag == "Ticket")
            {
                if (collider.GetComponent<Ticket>().ticketState == Ticket.TicketState.ReleaseDone)
                {
                    tickets.Add(collider.GetComponent<Ticket>());
                    collider.GetComponent<Ticket>().freezeTicket();
                    collider.GetComponent<Ticket>().ticketState = Ticket.TicketState.Done;
                }
            }
        }

        if (collider.tag == "Ticket")
        {
            collider.GetComponent<Ticket>().freezeTicket();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Ticket")
        {
            collider.GetComponent<Ticket>().unfreezeTicket();
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
