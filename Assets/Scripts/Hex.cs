using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x, z, y, q, yCtr;
    public int speed;
    public string typeHex;

    // pawns
    public Pawn pawnPresent;


    // GameObjects
    public GameObject upLeftHex, upRightHex, downLeftHex, downRightHex, leftHex, rightHex;
    public MapMaker mapMaker;
    public List<Hex> LNeighbors;


    private void Awake()
    {
        mapMaker = FindObjectOfType<MapMaker>().GetComponent<MapMaker>();
        LNeighbors = new List<Hex>();
    }

    // get neighbors
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
                            if(mapMaker.hexMapArray[this.x - 1, i, this.z, this.q] != null)
                            {
                                leftHex = mapMaker.hexMapArray[this.x - 1, i, this.z, this.q].gameObject;
                            }
                            else
                            {
                                leftHex = mapMaker.hexMapArray[this.x - 1, i - 1, this.z, this.q].gameObject;
                            }
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
                    if(mapMaker.hexMapArray[this.x - 1, this.y, this.z, this.q] != null)
                    {
                        leftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z, this.q].gameObject;
                    }
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
                            if (mapMaker.hexMapArray[this.x + 1, i, this.z, this.q] != null)
                            {
                                rightHex = mapMaker.hexMapArray[this.x + 1, i, this.z, this.q].gameObject;
                            }
                            else
                            {
                                rightHex = mapMaker.hexMapArray[this.x + 1, i - 1, this.z, this.q].gameObject;
                            }
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
                    if(mapMaker.hexMapArray[this.x + 1, this.y, this.z, this.q] != null)
                    {
                        rightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z, this.q].gameObject;
                    }
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


        // offset hexes
        if (z % 2 == 1)
        {
            // UPLEFT HEX
            #region
            // upleft hex space is in array range
            if (z + 1 < mapMaker.zHeight)
            {
                // left hex exists, check up
                if (mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the upleft hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        upLeftHex = mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set left hex one down
                            if (mapMaker.hexMapArray[this.x, i, this.z + 1, this.q] == null)
                            {
                                upLeftHex = mapMaker.hexMapArray[this.x, i - 1, this.z + 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set left hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x, i, this.z + 1, this.q] != null)
                                {
                                    upLeftHex = mapMaker.hexMapArray[this.x, i, this.z + 1, this.q].gameObject;
                                }
                                else
                                {
                                    upLeftHex = mapMaker.hexMapArray[this.x, i - 1, this.z + 1, this.q].gameObject;
                                }
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
                        if (mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q] != null)
                        {
                            upLeftHex = mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x, i, this.z + 1, this.q] != null)
                            {
                                upLeftHex = mapMaker.hexMapArray[this.x, i, this.z + 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            // UPRIGHT HEX
            #region
            // upright hex space is in array range
            if (x + 1 < mapMaker.xWidth && z + 1 < mapMaker.zHeight)
            {
                // upright hex exists, check up
                if (mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the upright hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        upRightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set upright hex one down
                            if (mapMaker.hexMapArray[this.x + 1, i, this.z + 1, this.q] == null)
                            {
                                upRightHex = mapMaker.hexMapArray[this.x + 1, i - 1, this.z + 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set upright hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x + 1, i, this.z + 1, this.q] != null)
                                {
                                    upRightHex = mapMaker.hexMapArray[this.x + 1, i, this.z + 1, this.q].gameObject;
                                }
                                else
                                {
                                    upRightHex = mapMaker.hexMapArray[this.x + 1, i - 1, this.z + 1, this.q].gameObject;
                                }
                                break;
                            }
                        }
                    }
                }
                // upright hex null, check down
                else
                {
                    // if clicked hex is at min height, make that hex the upright hex
                    if (this.y == 1)
                    {
                        if(mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q])
                        {
                            upRightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z + 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x + 1, i, this.z + 1, this.q] != null)
                            {
                                upRightHex = mapMaker.hexMapArray[this.x + 1, i, this.z + 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            // DOWNLEFT HEX
            #region
            // downLeftHex hex space is in array range
            if (z - 1 > 0)
            {
                // left hex exists, check up
                if (mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the downLeftHex hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        downLeftHex = mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set downLeftHex hex one down
                            if (mapMaker.hexMapArray[this.x, i, this.z - 1, this.q] == null)
                            {
                                downLeftHex = mapMaker.hexMapArray[this.x, i - 1, this.z - 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set left hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x, i, this.z - 1, this.q] != null)
                                {
                                    downLeftHex = mapMaker.hexMapArray[this.x, i, this.z - 1, this.q].gameObject;
                                }
                                else
                                {
                                    downLeftHex = mapMaker.hexMapArray[this.x, i - 1, this.z - 1, this.q].gameObject;
                                }
                                break;
                            }
                        }
                    }
                }
                // left hex null, check down
                else
                {
                    // if clicked hex is at min height, make that hex the downLeftHex hex
                    if (this.y == 1)
                    {
                        if (mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q] != null)
                        {
                            downLeftHex = mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x, i, this.z - 1, this.q] != null)
                            {
                                downLeftHex = mapMaker.hexMapArray[this.x, i, this.z - 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            // DOWNRIGHT HEX
            #region
            // downright hex space is in array range
            if (x + 1 < mapMaker.xWidth && z - 1 > 0)
            {
                // upright hex exists, check up
                if (mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the upright hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        downRightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set upright hex one down
                            if (mapMaker.hexMapArray[this.x + 1, i, this.z - 1, this.q] == null)
                            {
                                downRightHex = mapMaker.hexMapArray[this.x + 1, i - 1, this.z - 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set upright hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x + 1, i, this.z - 1, this.q] != null)
                                {
                                    downRightHex = mapMaker.hexMapArray[this.x + 1, i, this.z - 1, this.q].gameObject;
                                }
                                else
                                {
                                    downRightHex = mapMaker.hexMapArray[this.x + 1, i - 1, this.z - 1, this.q].gameObject;
                                }
                                break;
                            }
                        }
                    }
                }
                // upright hex null, check down
                else
                {
                    // if clicked hex is at min height, make that hex the upright hex
                    if (this.y == 1)
                    {
                        if (mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q])
                        {
                            downRightHex = mapMaker.hexMapArray[this.x + 1, this.y, this.z - 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x + 1, i, this.z - 1, this.q] != null)
                            {
                                downRightHex = mapMaker.hexMapArray[this.x + 1, i, this.z - 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
#endregion
        }
        else
        {
            // UPLEFT HEX
            #region
            // upleft hex space is in array range
            if (x - 1 > 0 && z + 1 < mapMaker.zHeight)
            {
                // upleft hex exists, check up
                if (mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the upleft hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        upLeftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set left hex one down
                            if (mapMaker.hexMapArray[this.x - 1, i, this.z, this.q] == null)
                            {
                                upLeftHex = mapMaker.hexMapArray[this.x - 1, i - 1, this.z + 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set left hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if(mapMaker.hexMapArray[this.x - 1, i, this.z + 1, this.q] != null)
                                {
                                    upLeftHex = mapMaker.hexMapArray[this.x - 1, i, this.z + 1, this.q].gameObject;
                                }
                                else
                                {
                                    upLeftHex = mapMaker.hexMapArray[this.x - 1, i - 1, this.z + 1, this.q].gameObject;
                                }
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
                        if(mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q])
                        {
                            if(mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q] != null)
                            {
                                upLeftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z + 1, this.q].gameObject;
                            }
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x - 1, i, this.z + 1, this.q] != null)
                            {
                                upLeftHex = mapMaker.hexMapArray[this.x - 1, i, this.z + 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            // UPRIGHT HEX
            #region
            // upright hex space is in array range
            if (z + 1 < mapMaker.zHeight)
            {
                // upright hex exists, check up
                if (mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the upright hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        upRightHex = mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set upright hex one down
                            if (mapMaker.hexMapArray[this.x, i, this.z + 1, this.q] == null)
                            {
                                upRightHex = mapMaker.hexMapArray[this.x, i - 1, this.z + 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set upright hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x, i, this.z + 1, this.q] != null)
                                {
                                    upRightHex = mapMaker.hexMapArray[this.x, i, this.z + 1, this.q].gameObject;
                                }
                                else
                                {
                                    upRightHex = mapMaker.hexMapArray[this.x, i - 1, this.z + 1, this.q].gameObject;
                                }
                                break;
                            }
                        }
                    }
                }
                // upright hex null, check down
                else
                {
                    // if clicked hex is at min height, make that hex the upright hex
                    if (this.y == 1)
                    {
                        if(mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q])
                        {
                            upRightHex = mapMaker.hexMapArray[this.x, this.y, this.z + 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x, i, this.z + 1, this.q] != null)
                            {
                                upRightHex = mapMaker.hexMapArray[this.x, i, this.z + 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            // DOWNLEFT HEX
            #region
            // downLeftHex hex space is in array range
            if (x - 1 > 0 && z - 1 > 0)
            {
                // downLeftHex hex exists, check up
                if (mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the downLeftHex hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        downLeftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set downLeftHex hex one down
                            if (mapMaker.hexMapArray[this.x - 1, i, this.z - 1, this.q] == null)
                            {
                                downLeftHex = mapMaker.hexMapArray[this.x - 1, i - 1, this.z - 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set left hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x - 1, i, this.z - 1, this.q] != null)
                                {
                                    downLeftHex = mapMaker.hexMapArray[this.x - 1, i, this.z - 1, this.q].gameObject;
                                }
                                else
                                {
                                    downLeftHex = mapMaker.hexMapArray[this.x - 1, i - 1, this.z - 1, this.q].gameObject;
                                }
                                break;
                            }
                        }
                    }
                }
                // left hex null, check down
                else
                {
                    // if clicked hex is at min height, make that hex the downLeftHex hex
                    if (this.y == 1)
                    {
                        if (mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q] != null)
                        {
                            downLeftHex = mapMaker.hexMapArray[this.x - 1, this.y, this.z - 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x - 1, i, this.z - 1, this.q] != null)
                            {
                                downLeftHex = mapMaker.hexMapArray[this.x - 1, i, this.z - 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            //DOWNRIGHT HEX
            #region
            // downright hex space is in array range
            if (z - 1 > 0)
            {
                // upright hex exists, check up
                if (mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q] != null)
                {
                    // if clicked hex is at max height, make that hex the upright hex
                    if (this.y == mapMaker.yTall - 1)
                    {
                        downRightHex = mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].gameObject;
                    }
                    // else check for higher hexes
                    else
                    {
                        for (int i = this.y; i <= mapMaker.yTall - 1; i++)
                        {
                            // went one too far up, set upright hex one down
                            if (mapMaker.hexMapArray[this.x, i, this.z - 1, this.q] == null)
                            {
                                downRightHex = mapMaker.hexMapArray[this.x, i - 1, this.z - 1, this.q].gameObject;
                                break;
                            }
                            // hit the top, set upright hex as this hex
                            else if (i == mapMaker.yTall - 1)
                            {
                                if (mapMaker.hexMapArray[this.x, i, this.z - 1, this.q] != null)
                                {
                                    downRightHex = mapMaker.hexMapArray[this.x, i, this.z - 1, this.q].gameObject;
                                }
                                else
                                {
                                    downRightHex = mapMaker.hexMapArray[this.x, i - 1, this.z - 1, this.q].gameObject;
                                }
                                break;
                            }
                        }
                    }
                }
                // upright hex null, check down
                else
                {
                    // if clicked hex is at min height, make that hex the upright hex
                    if (this.y == 1)
                    {
                        if (mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q])
                        {
                            downRightHex = mapMaker.hexMapArray[this.x, this.y, this.z - 1, this.q].gameObject;
                        }
                    }
                    // else check for lower hexes
                    else
                    {
                        for (int i = this.y; i > 0; i--)
                        {
                            // found a real hex
                            if (mapMaker.hexMapArray[this.x, i, this.z - 1, this.q] != null)
                            {
                                downRightHex = mapMaker.hexMapArray[this.x, i, this.z - 1, this.q].gameObject;
                                break;
                            }
                        }
                    }
                }
            }
#endregion
        }

        FillNeighborList();
    }

    public void ClearPathfind()
    {
        foreach(Hex neighborHex in LNeighbors)
        {
            neighborHex.DefaultColor();
            neighborHex.speed = 0;
        }
    }

    public void Pathfind(int PawnSpeed)
    {
        this.speed = PawnSpeed;
        foreach (Hex neighborHex in LNeighbors)
        {
            int cost = 0;
            if(neighborHex.y < this.y)
            {
                cost = 1;
            }
            else
            {
                cost = neighborHex.y - this.y + 1;
            }
            if (speed - cost > 0 && speed - cost > neighborHex.speed)
            {
                neighborHex.HighLight();
                neighborHex.speed = speed - cost;
                neighborHex.Pathfind(neighborHex.speed);
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

    public void DefaultColor()
    {
        transform.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.gray;
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
