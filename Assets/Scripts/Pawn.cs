using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {


    // stats
    public int speed;


    // abilities
    public bool flying;


    // state
    public bool isPlaced;


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
		
	}
	
	
	void Update ()
    {
		
	}
}
