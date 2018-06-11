using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

    public GameObject myPawn;
    public MyGameManager myGameManager;

    private void Awake()
    {
        myGameManager = FindObjectOfType<MyGameManager>();
    }



    // Use this for initialization
    void Start ()
    {
        if (isLocalPlayer == false)
        {
            print("nope");
            print(this.gameObject);
            return;
        }
        Debug.Log("This is my player " + this.gameObject);

        CmdSpawn();
    }
	
	// Update is called once per frame
	void Update () 
    {
		
        if(!isLocalPlayer)
        {
            return;
        }

	}

    [Command]
    void CmdSpawn()
    {
        GameObject go = Instantiate(myPawn);
        NetworkServer.Spawn(go);
        myGameManager.numPlayers++;
    }
}
