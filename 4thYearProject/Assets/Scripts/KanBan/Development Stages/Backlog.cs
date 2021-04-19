using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backlog : MonoBehaviour
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
        if(Player.instance.playerRole == Player.PlayerRole.ProductOwner)
        {
            if(collider.tag == "Ticket")
            {
                tickets.Add(collider.GetComponent<Ticket>());
                collider.GetComponent<Ticket>().freezeTicket();
                Debug.Log("Called");
            }
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
    public void removeTicket(int id)
    {
        for(int i =0; i < tickets.Count; i++)
        {
            if (tickets[i].ID == id)
            {
                tickets.Remove(tickets[i]);
            }
        }
    }

    private void updateTicketPos()
    {
        foreach(Ticket ticket in tickets)
        {
            ticket.SetOnBoard(this.transform.position);
        }
    }
}
