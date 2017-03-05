using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

    public GameObject selectedUnit;

    public TileType[] tilesTypes;
    int[,] tiles;

    int mapSizeX = 10;
    int mapSizeY = 10;

    void Start()
    {

        GenerateMapData();
        GenerateMapVisuals();
    }

    void GenerateMapData()
    {
        int x, y;
        // allocate map tiles
        tiles = new int[mapSizeX, mapSizeY];

        // initialize map tiles
        for (x = 0; x < mapSizeX; x++)
        {
            for (y = 0; y < mapSizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }

        // make a big swamp area
        for(x = 3; x <= 5; x++)
        {
            for(y = 0; y < 4; y++)
            {
                tiles[x, y] = 1;
            }
        }

        // lets make a u-shaped mountain range

        tiles[4, 4] = 2;
        tiles[5, 4] = 2;
        tiles[6, 4] = 2;
        tiles[7, 4] = 2;
        tiles[8, 4] = 2;

        tiles[4, 5] = 2;
        tiles[4, 6] = 2;
        tiles[8, 5] = 2;
        tiles[8, 6] = 2;
    }

    void GenerateMapVisuals()
    {
        // initialize map tiles
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                TileType tt = tilesTypes[tiles[x, y]];  // the tile type at this x and y

                GameObject go = (GameObject)Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);
                ClickableTile ct = go.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
            }
        }
    }

    public Vector3 TileCoordtoWorldCoord(int x, int y)
    {
        return new Vector3(x, y, 0);
    }

    public void MoveSelectedUnitTo(int x, int y)
    {
        // data
        selectedUnit.GetComponent<Unit>().tileX = x;
        selectedUnit.GetComponent<Unit>().tileY = y;
        // visual
        selectedUnit.transform.position = TileCoordtoWorldCoord(x, y);
    }
}
