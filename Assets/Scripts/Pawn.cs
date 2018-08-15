using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 3D model for a unit

public class Pawn : MonoBehaviour {

    // stats
    public int speedMax;
    public int speedLeft;
    public int height;
    public int size;

    // abilities
    public bool flying;

    // state
    public bool isPlaced;
    public int team;

    // movement
    public float adjustmentHeight = 0.146f;
    public Hex hexCurrent;

    // scripts
    public Hex hex;
    public MapMaker mapMaker;
    public MouseManager mouseManager;


    private void Awake()
    {
        mapMaker = FindObjectOfType<MapMaker>();
    }


    void Start ()
    {
        speedLeft = speedMax;
	}
	
	
	void Update ()
    {
		
	}
}
