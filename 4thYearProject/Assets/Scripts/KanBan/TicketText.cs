using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicketText : MonoBehaviour
{
    TextMeshPro ticketText;
    [SerializeField]Ticket ticket;

    // Start is called before the first frame update
    void Start()
    {
        ticketText = gameObject.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        ticketText.text = $"Ticket ID: {ticket.ID} \n" +
            $"Title: \n" +
            "User Story: ";
    }
}
