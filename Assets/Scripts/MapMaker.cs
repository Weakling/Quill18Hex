using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour {

    public GameObject grassHexPrefab, sandHexPrefab, rockHexPrefab, roadHexPrefab, lavaHexPrefab, snowHexPrefab, swampHexPrefab, dungeonHexPrefab;
    public GameObject waterHalfHexPrefab, iceHalfHexPrefab, lavaHalfHexPrefab, swampHalfHexPrefab, shadowHalfHexPrefab;
    public GameObject hexToInstantiate, defaultHexPrefab;


    //public TileType[] tilesTypes;
    public Hex[,,] hexMapArray;


    // size of map in terms of number of hex tiles
    public int xWidth;
    public int zHeight;
    public int yTall;

    //float xOffset = 0.882f;
    //float zOffset = 0.764f;
    float xOffset = 1f;
    float zOffset = 0.865f;
    public float yOffset = 0.133f;

    void Start ()
    {
        // grab real hex
        hexToInstantiate = lavaHexPrefab;

        // instantiate array
        hexMapArray = new Hex[xWidth, yTall, zHeight];

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
                GameObject hex_go = (GameObject)Instantiate(hexToInstantiate, new Vector3(xPos, 1, z * zOffset), Quaternion.identity); // instantiate
                hex_go.name = "Hex_" + x + "-" + z;                                                                             // set name to reletive position
                hex_go.transform.SetParent(this.transform);                                                                     // set parent for clean up              
                // hex map info
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().z = z;
                hexMapArray[x, 1, z] = hex_go.GetComponent<Hex>();   // set in array 
            }
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
        else if (Input.GetKeyDown(KeyCode.Exclaim))
        {
            hexToInstantiate = iceHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.At))
        {
            hexToInstantiate = lavaHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Hash))
        {
            hexToInstantiate = shadowHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.Dollar))
        {
            hexToInstantiate = swampHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha5))
        {
            hexToInstantiate = waterHalfHexPrefab;
        }
        else if (Input.GetKeyDown(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.Alpha5))
        {
            hexToInstantiate = waterHalfHexPrefab;
        }
    }

}
