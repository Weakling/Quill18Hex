using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x, z, y, q, yCtr;
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
        // check if I am a buried hex
        if(y + 1 < mapMaker.yTall)
        {
            if(mapMaker.hexMapArray[this.x, this.y + 1, this.z, this.q] != null)
            {
                return;
            }
        }

        // LEFT HEX
        #region
        // left hex space is in array range
        if (x - 1 > 0)
        {
            // left hex exists, check up
            if(mapMaker.hexMapArray[this.x - 1, this.y, this.z, this.q] != null)
            {
                // if clicked hex is at max height, make that hex the left hex
                if (this.y == mapMaker.yTall - 1)
                {
                    leftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z, this.q].gameObject;
                }
                // else check for higher hexes
                else
                {
                    for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                    {
                        // went one too far up, set left hex one down
                        if (mapMaker.hexMapArray[this.x - 1, i, this.z, this.q] == null)
                        {
                            leftHex = mapMaker.hexMapArray[this.x - 1, i - 1, this.z, this.q].gameObject;
                            break;
                        }
                        // hit the top, set left hex as this hex
                        else if (i == mapMaker.yTall - 1)
                        {
                            leftHex = mapMaker.hexMapArray[this.x - 1, i, this.z, this.q].gameObject;
                            break;
                        }
                    }
                }
            }
            // left hex null, check down
            else
            {
                // if clicked hex is at min height, make that hex the left hex
                if (this.y == 1)
                {
                    leftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z, this.q].gameObject;
                }
                // else check for lower hexes
                else
                {
                    for (int i = this.y; i > 0; i--)
                    {
                        // found a real hex
                        if (mapMaker.hexMapArray[this.x - 1, i, this.z, this.q] != null)
                        {
                            leftHex = mapMaker.hexMapArray[this.x - 1, i, this.z, this.q].gameObject;
                            break;
                        }
                    }
                }
            }  
        }
        #endregion

        // RIGHT HEX
        #region
        // right hex space is in array range
        if (x + 1 < mapMaker.xWidth)
        {
            // right hex exists, check up
            if (mapMaker.hexMapArray[this.x + 1, this.y, this.z, this.q] != null)
            {
                // if clicked hex is at max height, make that hex the left hex
                if (this.y == mapMaker.yTall - 1)
                {
                    rightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z, this.q].gameObject;
                }
                // else check for higher hexes
                else
                {
                    for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                    {
                        // went one too far up, set left hex one down
                        if (mapMaker.hexMapArray[this.x + 1, i, this.z, this.q] == null)
                        {
                            rightHex = mapMaker.hexMapArray[this.x + 1, i - 1, this.z, this.q].gameObject;
                            break;
                        }
                        // hit the top, set left hex as this hex
                        else if (i == mapMaker.yTall - 1)
                        {
                            rightHex = mapMaker.hexMapArray[this.x + 1, i, this.z, this.q].gameObject;
                            break;
                        }
                    }
                }
            }
            // left hex null, check down
            else
            {
                // if clicked hex is at min height, make that hex the left hex
                if (this.y == 1)
                {
                    rightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z, this.q].gameObject;
                }
                // else check for lower hexes
                else
                {
                    for (int i = this.y; i > 0; i--)
                    {
                        // found a real hex
                        if (mapMaker.hexMapArray[this.x + 1, i, this.z, this.q] != null)
                        {
                            rightHex = mapMaker.hexMapArray[this.x + 1, i, this.z, this.q].gameObject;
                            break;
                        }
                    }
                }
            }
        }
#endregion


        // upper hexes
        if (z % 2 == 1)
        {
            if(z + 1 < mapMaker.zHeight && mapMaker.hexMapArray[this.x , this.y, this.z + 1, this.q] != null)
            {
                if(mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].tag != "Hex Empty")
                {
                    upLeftHex = mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].gameObject;
                }
            }

            if (x + 1 < mapMaker.xWidth && z + 1 < mapMaker.zHeight && mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q].tag != "Hex Empty")
                {
                    upRightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q].gameObject;
                }
            }

            if (z - 1 > 0 && mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].tag != "Hex Empty")
                {
                    downLeftHex = mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].gameObject;
                }
            }

            if (x + 1 < mapMaker.xWidth && z - 1 > 0 && mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q].tag != "Hex Empty")
                {
                    downRightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q].gameObject;
                }
            }

            //GetColors(upLeftHex, upRightHex, downLeftHex, downRightHex);
        }
        else
        {
            if (x - 1 > 0 && z + 1 < mapMaker.zHeight && mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q].tag != "Hex Empty")
                {
                    upLeftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q].gameObject;
                }
            }

            if (z + 1 < mapMaker.zHeight && mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].tag != "Hex Empty")
                {
                    upRightHex = mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].gameObject;
                }
            }

            if (x - 1 > 0 && z - 1 > 0 && mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q].tag != "Hex Empty")
                {
                    downLeftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q].gameObject;
                }
            }

            if (z - 1 > 0 && mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q] != null)
            {
                if (mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].tag != "Hex Empty")
                {
                    downRightHex = mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].gameObject;
                }
            }
        }

        FillNeighborList();
    }

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
