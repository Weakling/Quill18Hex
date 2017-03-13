using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour {

    public GameObject hexPrefab;
    public GameObject hexToInstantiate;
    public TileType[] tilesTypes;
    public Hex[,,] hexMapArray;


    // size of map in terms of number of hex tiles
    int xWidth = 8;
    int zHeight = 8;
    int yTall = 8;

    //float xOffset = 0.882f;
    //float zOffset = 0.764f;
    float xOffset = 1f;
    float zOffset = 0.865f;
    public float yOffset = 0.133f;

    void Start ()
    {
        // grab real hex
        hexToInstantiate = tilesTypes[0].tileVisualPrefab;

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
                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 1, z * zOffset), Quaternion.identity); // instantiate
                hex_go.name = "Hex_" + x + "-" + z;                                                                             // set name to reletive position
                hex_go.transform.SetParent(this.transform);                                                                     // set parent for clean up              
                // hex map info
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().z = z;
                hexMapArray[x, 1, z] = hex_go.GetComponent<Hex>();   // set in array 
            }
        }
	}

}
