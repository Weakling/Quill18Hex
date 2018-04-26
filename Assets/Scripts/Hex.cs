using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x, z, y, q;
    public string typeHex;

    public GameObject upLeftHex, upRightHex, downLeftHex, downRightHex, leftHex, rightHex;

    private void Start()
    {
        
    }

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

        //return null;
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
