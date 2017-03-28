using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadWriteText : MonoBehaviour {

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
                    x = 1;
                    while (x < mapMaker.xWidth)
                    {
                        s = reader.ReadLine();
                        int myInt = (int) s[0];
                        MakeTile(myInt, x, y, z, 0);
                        x++;
                        Debug.Log(s);
                    }
                    z++;
                }
                y++;
            }

            //char[] delimiter = { ':' };
            //string[] fields = s.Split(delimiter);
            //Debug.Log(s);
            //s = reader.ReadLine();
        //}
    }

    private void MakeTile(int type, int x, int y, int z, int q)
    {
        if(type == 0)
        {
            GameObject newHex = Instantiate(emptyTile, mapMaker.hexMapArray[x, y, z, q].transform.position, Quaternion.identity);
            mapMaker.hexMapArray[x, y, z, q] = newHex.GetComponent<Hex>();
        }
        else if(type == 1)
        {
            Vector3 pos = new Vector3(mapMaker.hexMapArray[x, 1, z, q].transform.position.x, mapMaker.hexMapArray[x, 1, z, q].transform.position.y + y * mapMaker.yOffset, mapMaker.hexMapArray[x, 1, z, q].transform.position.z);
            GameObject newHex = Instantiate(grassTile, pos, Quaternion.identity);
            mapMaker.hexMapArray[x, y, z, q] = newHex.GetComponent<Hex>();
        }
    }
}
