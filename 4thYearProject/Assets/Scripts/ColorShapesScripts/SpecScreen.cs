using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecScreen : MonoBehaviour
{
    [SerializeField] Image square;
    [SerializeField] Image triangle;
    [SerializeField] Image Cylinder;

    [SerializeField] private Material red;
    [SerializeField] private Material Green;
    [SerializeField] private Material Blue;

    public string shape = "";
    public Color color;

    int imageNumSelect;
    int colorNumSelect;

    float timer = 0;
    float randomTimer = 3;

    public bool randomizing = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (randomizing == true)
        {
            timer += Time.deltaTime;

            if (timer < 3)
            {
                randomizeColors();
                randomizeShapes();
            }
        }
    }

    public void randomizeShapes()
    {
        imageNumSelect = Random.Range(0, 3);
        if (imageNumSelect == 0)
        {
            Cylinder.enabled = false;
            triangle.enabled = false;
            square.enabled = true;
            shape = "Cube";
        }
        else if (imageNumSelect == 1)
        {
            square.enabled = false;
            triangle.enabled = false;
            Cylinder.enabled = true;
            shape = "Cylinder";
        }
        else if (imageNumSelect == 2)
        {
            square.enabled = false;
            Cylinder.enabled = false;
            triangle.enabled = true;
            shape = "Pyramid";
        }
    }

    public void randomizeColors()
    {
        colorNumSelect = Random.Range(0, 3);
        if (imageNumSelect == 0)
        {
            Cylinder.color = red.color;
            triangle.color = red.color;
            square.color = red.color;

            color = red.color;

        }
        else if (imageNumSelect == 1)
        {
            Cylinder.color = Blue.color;
            triangle.color = Blue.color;
            square.color = Blue.color;

            color = Blue.color;
        }
        else if (imageNumSelect == 2)
        {
            Cylinder.color = Green.color;
            triangle.color = Green.color;
            square.color = Green.color;

            color = Green.color;
        }
    }

    public void randomize()
    {
        randomizing = true;
        timer = 0;
    }
}
