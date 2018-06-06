using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour {


    public List<Pawn> player1Army, player2Army;

    int numPlayers;
    int currentTurn;
    int phase;

    public bool create;

    private void Awake()
    {
        player1Army = new List<Pawn>();
        player2Army = new List<Pawn>();
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    void FillArmyLists()
    {

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

