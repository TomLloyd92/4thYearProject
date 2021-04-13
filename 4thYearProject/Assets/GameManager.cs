using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject team;
    [SerializeField] GameObject MiniGames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartObserveView()
    {
        team.SetActive(true);
    }

    public void StartParticipationMode()
    {
        MiniGames.SetActive(true);
    }
}
