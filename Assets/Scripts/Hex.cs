using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x, z, y, q;
    public int speed;
    public string typeHex;

    // GameObjects
    public GameObject upLeftHex, upRightHex, downLeftHex, downRightHex, leftHex, rightHex;
    public MapMaker mapMaker;
    public List<Hex> LNeighbors;


    private void Awake()
    {
        mapMaker = FindObjectOfType<MapMaker>().GetComponent<MapMaker>();
        LNeighbors = new List<Hex>();
    }

    public void GetNeighbours()
    {
        // left hex
        if (x - 1 > 0)
        {
            leftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z, this.q].gameObject;
        }


        // right hex
        if (x + 1 <= mapMaker.xWidth)
        {
            rightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z, this.q].gameObject;
        }
    }
        
        /*
        // upper hexes
        if (z % 2 == 1)
        {
            upLeftHex = GameObject.Find("Hex_" + (x) + "-" + (z + 1));
            upRightHex = GameObject.Find("Hex_" + (x + 1) + "-" + (z + 1));
            downLeftHex = GameObject.Find("Hex_" + (x) + "-" + (z - 1));
            downRightHex = GameObject.Find("Hex_" + (x + 1) + "-" + (z - 1));

            //GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }
        else
        {
            upLeftHex = GameObject.Find("Hex_" + (x - 1) + "-" + (z + 1));
            upRightHex = GameObject.Find("Hex_" + (x) + "-" + (z + 1));
            downLeftHex = GameObject.Find("Hex_" + (x - 1) + "-" + (z - 1));
            downRightHex = GameObject.Find("Hex_" + (x) + "-" + (z - 1));

            //GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }

        if (leftHex != null)
        {
            //leftHex.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
        if (rightHex != null)
        {
            //rightHex.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }

        FillNeighborList();
    }*/

    /*
    public void GetNeighbours()
    {
        // left hex
        leftHex = GameObject.Find("Hex_" + (x - 1) + "-" + z);

        // right hex
        rightHex = GameObject.Find("Hex_" + (x + 1) + "-" + z);

        // upper hexes
        if(z % 2 == 1)
        {
            upLeftHex = GameObject.Find("Hex_" + (x) + "-" + (z + 1));
            upRightHex = GameObject.Find("Hex_" + (x + 1) + "-" + (z + 1));
            downLeftHex = GameObject.Find("Hex_" + (x) + "-" + (z - 1));
            downRightHex = GameObject.Find("Hex_" + (x + 1) + "-" + (z - 1));

            //GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }
        else
        {
            upLeftHex = GameObject.Find("Hex_" + (x - 1) + "-" + (z + 1));
            upRightHex = GameObject.Find("Hex_" + (x) + "-" + (z + 1));
            downLeftHex = GameObject.Find("Hex_" + (x - 1) + "-" + (z - 1));
            downRightHex = GameObject.Find("Hex_" + (x) + "-" + (z - 1));

            //GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }

        if(leftHex != null)
        {
            //leftHex.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
        if(rightHex != null)
        {
            //rightHex.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }

        FillNeighborList();
    }
    */

    public void Pathfind()
    {
        print("this far");
        foreach (Hex neighborHex in LNeighbors)
        {
            if (speed - 1 > 0 && speed - 1 > neighborHex.speed)
            {
                neighborHex.HighLight();
                neighborHex.speed = speed - 1;
                neighborHex.Pathfind();
            }
        }
    }

    public void FillNeighborList()
    {
        if(leftHex != null)
        {
            LNeighbors.Add(leftHex.GetComponent<Hex>());
        }
        if (rightHex != null)
        {
            LNeighbors.Add(rightHex.GetComponent<Hex>());
        }
        if (upLeftHex != null)
        {
            LNeighbors.Add(upLeftHex.GetComponent<Hex>());
        }
        if (upRightHex != null)
        {
            LNeighbors.Add(upRightHex.GetComponent<Hex>());
        }
        if (downLeftHex != null)
        {
            LNeighbors.Add(downLeftHex.GetComponent<Hex>());
        }
        if (downRightHex != null)
        {
            LNeighbors.Add(downRightHex.GetComponent<Hex>());
        }

    }

    public void HighLight()
    {
        transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
    }

    void GetColors(GameObject moo1, GameObject moo2, GameObject moo3, GameObject moo4)
    {
        if (moo1 != null)
        {
            moo1.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
        if (moo2 != null)
        {
            moo2.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
        if (moo3 != null)
        {
            moo3.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
        if (moo4 != null)
        {
            moo4.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
    }
}
