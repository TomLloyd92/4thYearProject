using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCups : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = CupGameManager.instance.GetCupsKnocked().ToString("000000");
    }
}
