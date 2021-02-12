using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secretary : MonoBehaviour
{
    public GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;

    int wpCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        agent.SetDestination(wps[wpCounter].transform.position);

        float distance = Vector3.Distance(this.transform.position, wps[wpCounter].transform.position);

        Debug.Log(distance);

        if(distance < 1)
        {
            if(wpCounter < wps.Length - 1 )
            {
                wpCounter++;
            }
            else
            {
                wpCounter = 0;
            }
        }

    }
}
