using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDestroyBall()
    {
        StartCoroutine(destoryBall());
    }

    private IEnumerator destoryBall()
    {

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }  
}
