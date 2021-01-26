using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorer : MonoBehaviour
{
    private bool colorShape = false;
    public Material theColorMaterial;

    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = this.gameObject.GetComponent<Collider>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorShape)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }
    }

    public void colorShapes()
    {
        StartCoroutine(coloringShape());
    }


    void OnTriggerEnter(Collider shape) //while we are in the collider
    {
        shape.GetComponent<MeshRenderer>().material = theColorMaterial;
    }

    IEnumerator coloringShape()
    {
        colorShape = true;
        yield return new WaitForSeconds(2);
        colorShape = false;
    }


}
