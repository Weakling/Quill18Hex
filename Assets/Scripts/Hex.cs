using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x, z, y;

    public GameObject upLeftHex, upRightHex, downLeftHex, downRighthex, leftHex, rightHex;

    public Hex[] GetNeighbours()
    {
        // left hex
        GameObject leftHex = GameObject.Find("Hex_" + (x - 1) + "-" + z);
        // right hex
        GameObject rightHex = GameObject.Find("Hex_" + (x + 1) + "-" + z);

        // upper hexes
        if(z % 2 == 1)
        {
            GameObject upLeftHex = GameObject.Find("Hex_" + (x) + "-" + (z + 1));
            GameObject upRightHex = GameObject.Find("Hex_" + (x + 1) + "-" + (z + 1));
            GameObject downLeftHex = GameObject.Find("Hex_" + (x) + "-" + (z - 1));
            GameObject downRightHex = GameObject.Find("Hex_" + (x + 1) + "-" + (z - 1));

            GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }
        else
        {
            GameObject upLeftHex = GameObject.Find("Hex_" + (x - 1) + "-" + (z + 1));
            GameObject upRightHex = GameObject.Find("Hex_" + (x) + "-" + (z + 1));
            GameObject downLeftHex = GameObject.Find("Hex_" + (x - 1) + "-" + (z - 1));
            GameObject downRightHex = GameObject.Find("Hex_" + (x) + "-" + (z - 1));

            GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }

        if(leftHex != null)
        {
            leftHex.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }
        if(rightHex != null)
        {
            rightHex.transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.red;
        }

        return null;
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
