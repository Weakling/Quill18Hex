using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SyncValues : NetworkBehaviour {

    public TextMeshProUGUI txtLog;


    public int numPlayers;



    public void GOPlayerReady()
    {
        /*if(isServer)
        {
            RpcUpdateReady();
        }
        else
        {
            txtLog.text += "trying to call";
            CmdPlayerReady();
        }*/
        Debug.Log("Henry's Request");
        CmdPlayerReady();


        PlayerController pc = FindObjectOfType<PlayerController>();
        pc.CallDebug();
        if(pc.isLocalPlayer)
        {
            Debug.Log("is local player");
        }
    }

    [Command]
    void CmdPlayerReady()
    {
        Debug.Log("Moo!");
        txtLog.text += "Called command ";
        RpcUpdateReady();
        
    }
    
    [ClientRpc]
    void RpcUpdateReady()
    {
        txtLog.text += "Called rpc ";
    }
}
