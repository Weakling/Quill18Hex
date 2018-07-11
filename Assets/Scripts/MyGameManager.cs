using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class MyGameManager : NetworkBehaviour
{

    public PlayerController player1, player2;

    // lobby
    public TextMeshProUGUI txtReadyP1, txtReadyP2;

    public List<Pawn> player1Army, player2Army;
    public bool p1Ready, p2Ready, p1ArmyChosen, p2ArmyChosen;

    public int number;

    [SyncVar]
    public int numPlayers;

    int currentTurn;
    int phase;

    public bool create;

    private void Awake()
    {
        //player1Army = new List<Pawn>();
        player2Army = new List<Pawn>();
    }

    void Start ()
    {
        print("I'm here");
        CmdSpawnMyUnit();
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    void FillArmyLists()
    {

    }

    [Command]
    public void CmdSpawnMyUnit()
    {
        //GameObject go = Instantiate(player1Army[0].gameObject);
        //NetworkServer.Spawn(go); 
    }

    /*[Command]
    public void CmdPlayerReady(int PlayerNum)
    {
        if(PlayerNum == 1)
        {
            txtReadyP1.text = "yes";
        }
        else if(PlayerNum == 2)
        {
            txtReadyP2.text = "yes";
        }
        
    }*/

    [Command]
    public void CmdPlayerReady()
    {
        number++;
        if (number >= 2)
        {
            print(number);
        }
    }

    /*[Command]
    public void CmdPlayerReady(PlayerController Player)
    {
        if(Player == player1)
        {
            txtReadyP1.text = "yes";
        }
        else if(Player == player2)
        {
            txtReadyP2.text = "yes";
        }
    }*/



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

