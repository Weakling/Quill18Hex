using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class MyGameManager : NetworkBehaviour
{

    public PlayerController player1, player2, playerRef;

    // lobby
    public TextMeshProUGUI txtReadyP1Name, txtReadyP2Name, txtReadyP1, txtReadyP2;

    public List<Pawn> player1Army, player2Army;

    [SyncVar]
    public int numPlayersReady;

    public int numPlayers;

    public bool p1Ready, p2Ready, p1ArmyChosen, p2ArmyChosen;

    public int currentTurn;
    public int phase;

    public bool create;

    private void Awake()
    {
        //player1Army = new List<Pawn>();
        player2Army = new List<Pawn>();
    }

    void Start ()
    {
        print("I'm here");
	}
	


    public void NetPlayerReady(bool IAmReady)//bool IAMServer)
    {
        /*if(IAMServer)
        {
            RpcPlayerReady(true);
        }
        else
        {
            RpcPlayerReady(false);
        }*/
        //RpcPlayerReady(IAmReady);
        if(IAmReady)
        {
            numPlayersReady++;
        }
        else
        {
            numPlayersReady--;
        }
    }

    [ClientRpc]
    void RpcPlayerReady(bool IAmReady)//bool IAMServer)
    {
        /*if(IAMServer)
        {
            txtReadyP1.text = "Ready";
        }
        else
        {
            txtReadyP2.text = "Ready";
        }*/
        if(IAmReady)
        {
            numPlayers++;

            if (numPlayers == 1)
            {
                txtReadyP2.text = "Ready";
            }
            else if (numPlayers == 2)
            {
                txtReadyP1.text = "Ready";
            }
        }
        else
        {
            numPlayers--;
            txtReadyP1.text = "noready";
        }
    }

    

    /*public void PathfindMovement(int PawnSpeed)
    {
        this.speed = PawnSpeed;
        foreach (Hex neighborHex in LNeighbors)
        {
            // calculate cost
            int cost = 0;
            int trueCost = 0;
            if (neighborHex.y < this.y)
            {
                cost = 1;
            }
            else
            {
                cost = neighborHex.y - this.y + 1;
            }
            trueCost = neighborHex.y - this.y;

            // check if speed is enough to move to new hex
            if (speed - cost > 0 && speed - cost > neighborHex.speed)
            {
                if (trueCost <= mouseManager.pawnCurrent.height)
                {
                    if (!mapMaker.listHexField.Contains(neighborHex))
                    {
                        mapMaker.listHexField.Add(neighborHex);
                    }
                    neighborHex.HighLight();
                    neighborHex.speed = speed - cost;
                    neighborHex.PathfindMovement(neighborHex.speed);
                }
            }
        }
    }*/
}

