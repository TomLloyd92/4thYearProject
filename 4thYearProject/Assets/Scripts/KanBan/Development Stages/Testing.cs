using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
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
        if (Player.instance.playerRole == Player.PlayerRole.Developer )
        {
            if (collider.tag == "Ticket")
            {
                if(collider.GetComponent<Ticket>().ticketState == Ticket.TicketState.DevDone)
                {
                    Debug.Log("TICKET Placed in Testing");
                    tickets.Add(collider.GetComponent<Ticket>());
                    collider.GetComponent<Ticket>().freezeTicket();
                    Player.instance.currentTicket = collider.GetComponent<Ticket>();
                }
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(Player.instance.playerRole == Player.PlayerRole.Tester)
        {
            if (collider.tag == "Ticket")
            {
                collider.GetComponent<Ticket>().unfreezeTicket();
                tickets.Remove(collider.GetComponent<Ticket>());
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
