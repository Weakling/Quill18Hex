using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LobbyManager : MonoBehaviour {

    public PlayerController myPlayer;
    public MyGameManager myGameManager;
	
	void Start ()
    {
        //myGameManager = FindObjectOfType<MyGameManager>();

	}
	
	
	void Update ()
    {
		
	}


    public void GOReady()
    {
        //myGameManager.CmdPlayerReady(myPlayer.playerNum);
        myGameManager.CmdPlayerReady();
    }
}
