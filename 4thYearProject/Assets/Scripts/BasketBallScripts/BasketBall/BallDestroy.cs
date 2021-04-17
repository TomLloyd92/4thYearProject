using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    [SerializeField] GameObject basketball;
    [SerializeField] Transform pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BasketBall" )
        {
            other.gameObject.GetComponent<BasketBall>().startDestroyBall();
        }



        if (GameObject.FindGameObjectsWithTag("BasketBall").Length < 2)
        {
            Instantiate(basketball, pos.position, Quaternion.identity);
        }
    }
}
