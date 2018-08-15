using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    MyGameManager myGameManager;
    public bool isLobbyReady;

    private void Start()
    {
        // get game manager
        myGameManager = FindObjectOfType<MyGameManager>();

        // set players
        SetPlayers();
        
        // local player
        if (!isLocalPlayer)
        {
            return;
        }

        CmdSetName();
    }

    void SetPlayers()
    {
        if (isServer)
        {
            if (isLocalPlayer)
            {
                myGameManager.player1 = this.GetComponent<PlayerController>();
                myGameManager.playerRef = myGameManager.player1;
            }
            else
            {
                myGameManager.player2 = this.GetComponent<PlayerController>();
            }
        }
        // not server
        else
        {
            if (isLocalPlayer)
            {
                myGameManager.player2 = this.GetComponent<PlayerController>();
                myGameManager.playerRef = myGameManager.player2;
            }
            else
            {
                myGameManager.player1 = this.GetComponent<PlayerController>();
            }
        }
    }

    public void NetPlayerReady()
    {
        /*if(isServer)
        {
            CmdPlayerReady(true);
        }
        else
        {
            CmdPlayerReady(false);
        }*/
        isLobbyReady = !isLobbyReady;
        CmdPlayerReady(isLobbyReady);
    }

    [Command]
    public void CmdPlayerReady(bool IAmReady)//bool IAmServer)
    {
        /*if(IAmServer)
        {
            myGameManager.NetPlayerReady(true);
        }
        else
        {
            myGameManager.NetPlayerReady(false);
        }*/
        myGameManager.NetPlayerReady(IAmReady);
    }

    [Command]
    void CmdSetName()
    {
        RpcSetName();
    }

    [ClientRpc]
    void RpcSetName()
    {
        this.transform.name = SavePPManager.GetString(SavePPManager.PrefString.PlayerName.ToString(), "player");
    }
}
