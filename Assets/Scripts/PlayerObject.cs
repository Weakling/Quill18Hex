using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

    private void Awake()
    {
        if(!isLocalPlayer)
        {
            return;
            Debug.Log("This is my player " + this.gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
