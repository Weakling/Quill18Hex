using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncValues : NetworkBehaviour {

    [SyncVar]
    public int numPlayers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    


    
    public void GOPlayerReady()
    {
        print("yup");
        numPlayers++;
        if(numPlayers > 5)
        {

        }
    }
}
