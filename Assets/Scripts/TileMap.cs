using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

    public TileType[] tilesTypes;
    int[,] tiles;

    int mapSizeX = 10;
    int mapSizeY = 10;

    void Start()
    {
        // allocate map tiles
        tiles = new int[mapSizeX, mapSizeY];
        // initialize map tiles
        for(int x = 0; x < mapSizeX; x++)
        {
            for(int y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }
    }
}
