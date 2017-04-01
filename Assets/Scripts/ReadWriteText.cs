using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadWriteText : MapMaker {

    private string[] tileNames;
    private MapMaker mapMaker;
    public GameObject grassTile;
    public GameObject emptyTile;

	// Use this for initialization
	void Start ()
    {
        mapMaker = FindObjectOfType<MapMaker>().GetComponent<MapMaker>();

        //SaveToFile();
        //ReadFromFile();
	}
	

	void Update ()
    {
        if(Input.anyKeyDown)
        {
            if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
            {
                //Debug.Log(Input.inputString);
            }
        }
	}

    public void SaveToFile()
    {
        StreamWriter writer = new StreamWriter(@"C:\MapData\Maps.txt");
        char output = 'n';
        int x = 1;
        int y = 1;
        int z = 1;

        while (y < mapMaker.yTall)
        {
            z = 1;
            while (z < mapMaker.zHeight)
            {
                x = 1;
                while (x < mapMaker.xWidth)
                {
                    // default empty hex
                    output = '0';
                    // check empty array..
                    if(mapMaker.hexMapArray[x, y, z, 0] != null)
                    {
                        output = mapMaker.hexMapArray[x, y, z, 0].typeHex;
                    }
                    // write q 0
                    writer.WriteLine(output);
                    //default empty hex
                    output = '0';
                    // check empty array
                    if (mapMaker.hexMapArray[x, y, z, 1] != null)
                    {
                        output = mapMaker.hexMapArray[x, y, z, 1].typeHex;
                    }
                    // write q 1
                    writer.WriteLine(output);
                    x++;
                }
                z++;
            }
            y++;
        }
        writer.Close();
    }

    /*private char SaveInfo(int x, int y, int z, int q)
    {
        Debug.Log(mapMaker.hexMapArray[x, y, z, q]);
        return mapMaker.hexMapArray[x, y, z, q].typeHex;
    }*/

    public void ReadFromFile()
    {
        StreamReader reader = new StreamReader(@"C:\MapData\Maps.txt");

        mapMaker.ResetMap();
        //string s = reader.ReadLine();
        string s;
        int x = 1;
        int y = 1;
        int z = 1;
        //FIX ALL THIS STUFF HERE
        //while (s != null)
        //{
            while (y < mapMaker.yTall)
            {
                z = 1;
                while (z < mapMaker.zHeight)
                {
                    x =1;
                    while (x < mapMaker.xWidth)
                    {
                        s = reader.ReadLine();
                        //int myInt = int.Parse(s);
                        MakeTile(s, x, y, z, 0);
                        Debug.Log(s);
                        s = reader.ReadLine();
                        MakeTile(s, x, y, z, 1);
                        x++;
                        Debug.Log(s);
                    }
                    z++;
                }
                y++;
            }
        reader.Close();

            //char[] delimiter = { ':' };
            //string[] fields = s.Split(delimiter);
            //Debug.Log(s);
            //s = reader.ReadLine();
        //}
    }

    private void MakeTile(string type, int x, int y, int z, int q)
    {
        if (type == "t")
        {
            // instantiate new hex
            GameObject newEmptyHex = Instantiate(defaultHexPrefab, mapMaker.hexPosArray[x, y, z, 0].transform.position, Quaternion.identity);
            // set vars
            newEmptyHex.GetComponent<Hex>().x = mapMaker.hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().x;
            newEmptyHex.GetComponent<Hex>().y = mapMaker.hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().y;
            newEmptyHex.GetComponent<Hex>().z = mapMaker.hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().z;
            // set array
            mapMaker.hexMapArray[x, y, z, 0] = newEmptyHex.GetComponent<Hex>();
            return;
        }
        else if (type == "0")
        {
            return;
        }
        else if(type == "1")
        {
            hexToInstantiate = dungeonHexPrefab;
        }
        else if (type == "2")
        {
            hexToInstantiate = grassHexPrefab;
        }
        else if (type == "3")
        {
            hexToInstantiate = lavaHexPrefab;
        }
        else if (type == "4")
        {
            hexToInstantiate = roadHexPrefab;
        }
        else if (type == "5")
        {
            hexToInstantiate = rockHexPrefab;
        }
        else if (type == "6")
        {
            hexToInstantiate = sandHexPrefab;
        }
        else if (type == "7")
        {
            hexToInstantiate = snowHexPrefab;
        }
        else if (type == "8")
        {
            hexToInstantiate = swampHexPrefab;
        }
        else if (type == "p")
        {
            hexToInstantiate = iceHalfHexPrefab;
        }
        else if (type == "o")
        {
            hexToInstantiate = lavaHalfHexPrefab;
        }
        else if (type == "i")
        {
            hexToInstantiate = shadowHalfHexPrefab;
        }
        else if (type == "u")
        {
            hexToInstantiate = swampHalfHexPrefab;
        }
        else if (type == "y")
        {
            hexToInstantiate = waterHalfHexPrefab;
        }
        //Vector3 pos = new Vector3(mapMaker.hexMapArray[x, 1, z, q].transform.position.x, mapMaker.hexMapArray[x, 1, z, q].transform.position.y + y * mapMaker.yOffset, mapMaker.hexMapArray[x, 1, z, q].transform.position.z);

        GameObject newHex = Instantiate(hexToInstantiate, mapMaker.hexPosArray[x, y, z, q].transform.position, Quaternion.identity);
        newHex.GetComponent<Hex>().x = mapMaker.hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().x;
        newHex.GetComponent<Hex>().y = mapMaker.hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().y;
        newHex.GetComponent<Hex>().z = mapMaker.hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().z;
        mapMaker.hexMapArray[x, y, z, q] = newHex.GetComponent<Hex>();

        // need to move empty and stuff
        if(newHex.GetComponent<Hex>().y == 1 && mapMaker.hexMapArray[x, 0, z, 0] == null)
        {
            Debug.Log("Got his far");
            Vector3 pos = new Vector3(mapMaker.hexPosArray[x, y, z, 0].transform.position.x, 1 - mapMaker.yOffset, mapMaker.hexPosArray[x, y, z, 0].transform.position.z);
            // instantiate new hex
            newHex = Instantiate(defaultHexPrefab, pos, Quaternion.identity);
            // set vars
            newHex.GetComponent<Hex>().x = mapMaker.hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().x;
            newHex.GetComponent<Hex>().y = 0;
            newHex.GetComponent<Hex>().z = mapMaker.hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().z;
            newHex.GetComponent<Hex>().q = 0;

            // renderer disable
            MeshRenderer ourHitMeshRenderer = newHex.GetComponentInChildren<MeshRenderer>();
            MeshCollider ourHitMeshCollider = newHex.GetComponentInChildren<MeshCollider>();
            ourHitMeshRenderer.enabled = false;
            ourHitMeshCollider.enabled = false;

            // set empty array
            mapMaker.hexMapArray[x, 0, z, 0] = newHex.GetComponent<Hex>();    // set empty hex array
        }
    }

}
