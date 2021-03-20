using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanBanBoard : MonoBehaviour
{
    Ticket[] allTickets;

    [SerializeField] public Backlog backlog;
    [SerializeField] public InDev inDev;
    [SerializeField] public Testing testing;
    [SerializeField] public Release release;
    [SerializeField] public Done done;

    public Backlog GetBacklog()
    {
        return backlog;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
