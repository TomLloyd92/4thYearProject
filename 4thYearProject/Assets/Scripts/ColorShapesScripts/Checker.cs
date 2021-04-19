using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] SpecScreen shapeOne;
    [SerializeField] SpecScreen shapeTwo;

    static int shapesCompleted = 0;

    Collider collider;
    bool checkShape = false;

    private void Start()
    {
        collider = this.gameObject.GetComponent<Collider>();
    }

    public void checkShapes()
    {
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkShape)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }

    public void startCheckingShapes()
    {
        StartCoroutine(CheckShape());
    }

    IEnumerator CheckShape()
    {
        checkShape = true;
        yield return new WaitForSeconds(2);
        checkShape = false;
    }

    void OnTriggerEnter(Collider shape) //while we are in the collider
    {
        Debug.Log("CHECKING SHAPE");
        Debug.Log(shape.tag);
        Debug.Log(shape.GetComponent<MeshRenderer>().material.color); 

        Debug.Log(shapeOne.shape);
        Debug.Log(shapeOne.color);

        Debug.Log(shapeTwo.shape);
        Debug.Log(shapeTwo.color);


        //
        if (shape.tag == shapeOne.shape && shapeOne.color == shape.GetComponent<MeshRenderer>().material.color)
        {
            Destroy(shape.gameObject);
            Debug.Log("Correct");
            shapesCompleted += 1;
            CheckWin();
        }
        else if (shape.tag == shapeTwo.shape && shapeTwo.color == shape.GetComponent<MeshRenderer>().material.color)
        {
            Destroy(shape.gameObject);
            shapesCompleted += 1;
            CheckWin();

            Debug.Log("Correct");
        }

    }

    private void CheckWin()
    {
       if(shapesCompleted == 2)
        {
            Player.instance.currentTicket.ticketState = Ticket.TicketState.DevDone;
            shapesCompleted = 0;
        }
    }
}
