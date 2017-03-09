using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaker : MonoBehaviour {

    public GameObject hexPrefab;

    public TileType[] tilesTypes;


    // size of map in terms of number of hex tiles
    int width = 8;
    int height = 8;

    //float xOffset = 0.882f;
    //float zOffset = 0.764f;
    float xOffset = 1f;
    float zOffset = .865f;

    void Start ()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;
                // are we on an odd row?
                if(y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }
                // hex gameobject info
                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);
                hex_go.name = "Hex_" + x + "-" + y;
                hex_go.transform.SetParent(this.transform);
                // hex map info
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().y = y;
                
            }
        }
	}
	
	void Update ()
    {
        
    }
}
