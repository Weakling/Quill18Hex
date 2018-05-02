using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapMaker : MonoBehaviour {

    public GameObject grassHexPrefab, sandHexPrefab, rockHexPrefab, roadHexPrefab, lavaHexPrefab, snowHexPrefab, swampHexPrefab, dungeonHexPrefab;
    public GameObject waterHalfHexPrefab, iceHalfHexPrefab, lavaHalfHexPrefab, swampHalfHexPrefab, shadowHalfHexPrefab;
    public GameObject hexToInstantiate, defaultHexPrefab, hexPosHolder;

    // variables
    public bool mapMaking;

    //public TileType[] tilesTypes;
    public Hex[,,,] hexMapArray;
    public GameObject[,,,] hexPosArray;
    public GameObject placeHolder;
    List<Hex> listAllHex;
    public List<Hex> listHexField;


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

    private void Awake()
    {
        listHexField = new List<Hex>();
    }

    void Start ()
    {
        // grab real hex
        hexToInstantiate = grassHexPrefab;

        // instantiate arrays and lists
        hexMapArray = new Hex[xWidth, yTall, zHeight, qStacked];
        hexPosArray = new GameObject[xWidth, yTall, zHeight, qStacked];
        listAllHex = new List<Hex>();

        // fill map base..
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
                hex_go.name = "Base Hex_" + x + "-" + z;                                                                        // set name to reletive position
                hex_go.transform.SetParent(this.transform);                                                                     // set parent for clean up              
                // hex map info
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().z = z;
                hexMapArray[x, 1, z, 0] = hex_go.GetComponent<Hex>();   // set in array 
            }
        }

        // fill map positions
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
                    hexPosArray[xx, yy, zz, 0] = Instantiate(placeHolder, pos, Quaternion.identity, hexPosHolder.transform);
                    hexPosArray[xx, yy, zz, 0].gameObject.GetComponent<Hex>().x = xx;
                    hexPosArray[xx, yy, zz, 0].gameObject.GetComponent<Hex>().y = yy;
                    hexPosArray[xx, yy, zz, 0].gameObject.GetComponent<Hex>().z = zz;
                    hexPosArray[xx, yy, zz, 0].gameObject.GetComponent<Hex>().q = 0;
                    // q 1
                    pos = new Vector3(hexMapArray[xx, 1, zz, 0].transform.position.x, (((yy - 1) * yOffset) + halfYOffset) + 1, hexMapArray[xx, 1, zz, 0].transform.position.z);
                    hexPosArray[xx, yy, zz, 1] = Instantiate(placeHolder, pos, Quaternion.identity, hexPosHolder.transform);
                    hexPosArray[xx, yy, zz, 1].gameObject.GetComponent<Hex>().x = xx;
                    hexPosArray[xx, yy, zz, 1].gameObject.GetComponent<Hex>().y = yy;
                    hexPosArray[xx, yy, zz, 1].gameObject.GetComponent<Hex>().z = zz;
                    hexPosArray[xx, yy, zz, 1].gameObject.GetComponent<Hex>().q = 1;

                    // increment
                    xx++;
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

    public void ResetMap()
    {
        // kill map
        int xx = 0;
        int yy = 0;
        int zz = 0;
        while (yy < yTall)
        {
            zz = 0;
            while (zz < zHeight)
            {
                xx = 0;
                while (xx < xWidth)
                {
                    // delete
                    if(hexMapArray[xx, yy, zz, 0] != null)
                    {
                        Destroy(hexMapArray[xx, yy, zz, 0].gameObject);
                        hexMapArray[xx, yy, zz, 0] = null;
                    }
                    // q 1
                    if (hexMapArray[xx, yy, zz, 1] != null)
                    {
                        Destroy(hexMapArray[xx, yy, zz, 1].gameObject);
                        hexMapArray[xx, yy, zz, 1] = null;
                    }
                    // increment
                    xx++;
                }
                zz++;
            }
            yy++;
        }
    }

    public void SaveButtonClicked()
    {

    }

    // save every map position as its hex type in text file
    public void SaveToFile()
    {
        // declare vars
        StreamWriter writer = new StreamWriter(@"C:\MapData\Maps.txt");
        //char output = 'n';
        string output = "";
        int y = 1;

        // loop through all dimensions and write hex type in text file
        while (y < yTall)
        {
            #region
            int z = 1;
            while (z < zHeight)
            {
                int x = 1;
                while (x < xWidth)
                {
                    //output = '0';                                   // default output to empty hex
                    if (hexMapArray[x, y, z, 0] != null)            // check empty array..
                    {
                        output = output + hexMapArray[x, y, z, 0].typeHex;   // set hex type if not empty
                    }
                    else
                    {
                        output = output + "0";
                    }
                    //Debug.Log(output);
                    //writer.WriteLine(output);                       // write to q 0

                    //output = '0';                                   //default output to empty hex
                    if (hexMapArray[x, y, z, 1] != null)            // check empty array..
                    {
                        output = output + hexMapArray[x, y, z, 1].typeHex;
                    }
                    else
                    {
                        output = output + "0";
                    }
                    //Debug.Log(output);
                    //writer.WriteLine(output);                       // write to q 1
                    x++;
                }
                z++;
            }
            y++;
            #endregion
        }
        writer.WriteLine(output);
        // close writer
        writer.Close();                                             
    }

    // read text file and call MakeHex method for every line
    public void ReadFromFile()
    {
        // delete all map hexes
        ResetMap();
        
        // vars
        StreamReader reader = new StreamReader(@"C:\MapData\Maps.txt");
        string s;
        int y = 1;

        s = reader.ReadToEnd();
        int ctr = 0;
        // loop through all dimensions and read hex type from text file
        while (y < yTall)
        {
            #region
            int z = 1;
            while (z < zHeight)
            {
                int x = 1;
                while (x < xWidth)
                {
                    MakeHex(s[ctr], x, y, z, 0);     // make hex from number type
                    //Debug.Log(s[ctr]);               // debug
                    ctr++;
                    
                    MakeHex(s[ctr], x, y, z, 1);     // make hex from number type
                    //Debug.Log(s[ctr]);               // debug
                    ctr++;
                    

                    x++;
                }
                z++;
            }
            y++;
            #endregion
        }
        // close reader
        reader.Close();

        if(!mapMaking)
        {
            // get all neighbors in hex list
            GetAllNeighbors();
        }
        
    }

    private void GetAllNeighbors()
    {
        foreach(Hex listHex in listAllHex)
        {
            listHex.GetNeighbours();
        }
    }

    private void MakeHex(char type, int x, int y, int z, int q)
    {
        // hex to make is default
        if (type == 't')
        {
            if(mapMaking)
            {
                #region
                // instantiate new hex at position array q 0 (since it's default base hex
                GameObject newEmptyHex = Instantiate(defaultHexPrefab, hexPosArray[x, y, z, 0].transform.position, Quaternion.identity);

                // set default hex pos vars from pos array
                newEmptyHex.GetComponent<Hex>().x = hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().x;
                newEmptyHex.GetComponent<Hex>().y = hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().y;
                newEmptyHex.GetComponent<Hex>().z = hexPosArray[x, y, z, 0].gameObject.GetComponent<Hex>().z;

                // set default hex in map array
                hexMapArray[x, y, z, 0] = newEmptyHex.GetComponent<Hex>();
            }
            // stop here
            return;
            #endregion
        }

        // find type of hex if it's not default
        else if (type == '0')
        {
            #region
            return;
        }
        else if (type == '1')
        {
            hexToInstantiate = dungeonHexPrefab;
        }
        else if (type == '2')
        {
            hexToInstantiate = grassHexPrefab;
        }
        else if (type == '3')
        {
            hexToInstantiate = lavaHexPrefab;
        }
        else if (type == '4')
        {
            hexToInstantiate = roadHexPrefab;
        }
        else if (type == '5')
        {
            hexToInstantiate = rockHexPrefab;
        }
        else if (type == '6')
        {
            hexToInstantiate = sandHexPrefab;
        }
        else if (type == '7')
        {
            hexToInstantiate = snowHexPrefab;
        }
        else if (type == '8')
        {
            hexToInstantiate = swampHexPrefab;
        }
        else if (type == 'p')
        {
            hexToInstantiate = iceHalfHexPrefab;
        }
        else if (type == 'o')
        {
            hexToInstantiate = lavaHalfHexPrefab;
        }
        else if (type == 'i')
        {
            hexToInstantiate = shadowHalfHexPrefab;
        }
        else if (type == 'u')
        {
            hexToInstantiate = swampHalfHexPrefab;
        }
        else if (type == 'y')
        {
            hexToInstantiate = waterHalfHexPrefab;
            #endregion
        }

        // instantiate new hex at pos array position
        GameObject newHex = Instantiate(hexToInstantiate, hexPosArray[x, y, z, q].transform.position, Quaternion.identity);

        // get pos vars from pos array
        newHex.GetComponent<Hex>().x = hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().x;
        newHex.GetComponent<Hex>().y = hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().y;
        newHex.GetComponent<Hex>().z = hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().z;
        newHex.GetComponent<Hex>().q = hexPosArray[x, y, z, q].gameObject.GetComponent<Hex>().q;

        // name new hex
        newHex.name = "Hex_" + x + "-" + z + "-" + y;

        // set new hex in map array
        hexMapArray[x, y, z, q] = newHex.GetComponent<Hex>();

        // set new hex in hex list
        if (!mapMaking)
        {
            listAllHex.Add(newHex.GetComponent<Hex>());
        }
        
    }

    // inputs to change hexToInstantiate type
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
