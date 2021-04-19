using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerRole
    {
        NoRole,
        ProductOwner,
        Developer,
        Tester,
        Release
    }

    public PlayerRole playerRole = PlayerRole.NoRole;

    public void SetNoRole()
    {
        playerRole = PlayerRole.NoRole;
    }

    public void SetProductOwner()
    {
        Debug.Log("SET AS PRODUCT OWNER");
        playerRole = PlayerRole.ProductOwner;
    }

    public void SetDeveloper()
    {
        playerRole = PlayerRole.Developer;
    }

    public void SetTester()
    {
        playerRole = PlayerRole.Tester;
    }

    public void SetRelease()
    {
        playerRole = PlayerRole.Release;
    }

    //Singleton static instance
    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
