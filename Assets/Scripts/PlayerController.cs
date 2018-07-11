﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public int playerNum;
    MyGameManager myGameManager;
    LobbyManager myLobbyManager;

    private void Start()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        //FindManagers();

        
    }

    private void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
    }




    void FindManagers()
    {
        myGameManager = FindObjectOfType<MyGameManager>();
        myLobbyManager = FindObjectOfType<LobbyManager>();

        if (myGameManager.player1 == null)
        {
            myGameManager.player1 = this.GetComponent<PlayerController>();
            playerNum = 1;
        }
        else if (myGameManager.player2 == null)
        {
            myGameManager.player2 = this.GetComponent<PlayerController>();
            playerNum = 2;
        }
        else
        {
            Debug.LogError("No available player slots");
        }

        myLobbyManager.myPlayer = this.GetComponent<PlayerController>();
    }
}
