using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cubeShape;
    public GameObject cylinderShape;
    public GameObject pyramidShape;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCube()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(cubeShape, this.transform.position, Quaternion.identity);
    }

    public void spawnCylinder()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(cylinderShape, this.transform.position, Quaternion.identity);
    }
    public void spawnPyramid()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(pyramidShape, this.transform.position, Quaternion.identity);
    }

}
