﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour {

    public GameObject grassHexPrefab, sandHexPrefab, rockHexPrefab, roadHexPrefab, lavaHexPrefab, snowHexPrefab, swampHexPrefab, dungeonHexPrefab;
    public GameObject waterHalfHexPrefab, iceHalfHexPrefab, lavaHalfHexPrefab, swampHalfHexPrefab, shadowHalfHexPrefab;
    public GameObject hexToInstantiate, defaultHexPrefab;


    //public TileType[] tilesTypes;
    public Hex[,,,] hexMapArray;
    public GameObject[,,,] hexPosArray;
    public GameObject placeHolder;


    // size of map in terms of number of hex tiles
    public int xWidth;
    public int zHeight;
    public int yTall;
    public int qStacked = 2;

    //float xOffset = 0.882f;
    //float zOffset = 0.764f;
    float xOffset = 1f;
    float zOffset = 0.865f;
    public float yOffset = 0.133f;
    public float halfYOffset = 0.0667f;

    void Start ()
    {
        // grab real hex
        hexToInstantiate = grassHexPrefab;

        // instantiate arrays
        hexMapArray = new Hex[xWidth, yTall, zHeight, qStacked];
        hexPosArray = new GameObject[xWidth, yTall, zHeight, qStacked];

        // fill map..
        for (int x = 1; x < xWidth; x++)
        {
            for (int z = 1; z < zHeight; z++)
            {
                float xPos = x * xOffset;
                // are we on an odd row?
                if(z % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }
                // hex gameobject info
                GameObject hex_go = (GameObject)Instantiate(defaultHexPrefab, new Vector3(xPos, 1, z * zOffset), Quaternion.identity); // instantiate
                hex_go.name = "Hex_" + x + "-" + z;                                                                             // set name to reletive position
                hex_go.transform.SetParent(this.transform);                                                                     // set parent for clean up              
                // hex map info
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().z = z;
                hexMapArray[x, 1, z, 0] = hex_go.GetComponent<Hex>();   // set in array 
            }
        }

        int xx = 1;
        int yy = 1;
        int zz = 1;
        while (yy < yTall)
        {
            zz = 1;
            while (zz < zHeight)
            {
                xx = 1;
                while (xx < xWidth)
                {
                    // weird y pos calculation due to yy array starting at 1. This starts pos at 0 and keeps loop condition at 1.
                    Vector3 pos = new Vector3(hexMapArray[xx, 1, zz, 0].transform.position.x, ((yy - 1) * yOffset) + 1, hexMapArray[xx, 1, zz, 0].transform.position.z);
                    hexPosArray[xx, yy, zz, 0] = Instantiate(placeHolder, pos, Quaternion.identity);
                    xx++;
                    //ADD Q 1 TO THIS AREA!!
                }
                zz++;
            }
            yy++;
        }
    }



    void Update()
    {

        ChangeHexType();
        
    }

    void ChangeHexType()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            hexToInstantiate = dungeonHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hexToInstantiate = grassHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hexToInstantiate = lavaHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            hexToInstantiate = roadHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            hexToInstantiate = rockHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            hexToInstantiate = sandHexPrefab;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            hexToInstantiate = snowHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            hexToInstantiate = swampHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            hexToInstantiate = iceHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            hexToInstantiate = lavaHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            hexToInstantiate = shadowHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            hexToInstantiate = swampHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha5))
        {
            hexToInstantiate = waterHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            hexToInstantiate = waterHalfHexPrefab;
        }
    }

}
