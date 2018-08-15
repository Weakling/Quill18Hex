using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.Networking;

public class ButtonCalls : MonoBehaviour {

    public TextMeshProUGUI txtLog;
    PlayerController pc;

    public void GOPlayerReady()
    {
        /*Debug.Log("Button clicked");

        PlayerController pc = FindObjectOfType<PlayerController>();
        if (pc.isLocalPlayer)
        {
            txtLog.text = "LOCAL PLAYER";
        }
        else
        {
            
            txtLog.text = "NOT LOCAL PLAYER";
        }
        pc.NetPlayerReady();*/

        pc = FindObjectOfType<PlayerController>();
        pc.NetPlayerReady();

    }

}
