using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBaseBall : MonoBehaviour
{
    [SerializeField] GameObject baseball;
    [SerializeField] Transform pos;

    [SerializeField] GameObject cups;
    [SerializeField] Transform cupsSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Baseball")
        {
            other.gameObject.GetComponent<Baseball>().startDestroyBall();
            startDestroyAllCups();
        }

        if (GameObject.FindGameObjectsWithTag("Baseball").Length < 2)
        {
            Instantiate(baseball, pos.position, Quaternion.identity);
        }
    }

    public void startDestroyAllCups()
    {
        StartCoroutine(destoryCups());
        StartCoroutine(createAStack());
    }

    private IEnumerator destoryCups()
    {
        yield return new WaitForSeconds(1.5f);

        GameObject cupStack = GameObject.FindGameObjectWithTag("CupStack");

        Destroy(cupStack);
    }

    private IEnumerator createAStack()
    {
        yield return new WaitForSeconds(3);

        Instantiate(cups, cupsSpawn);
    }

}
