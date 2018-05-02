using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {


    // our hit object
    private GameObject ourHitObject;

    // hit hex

    // new hex

    // Game objects
    public Pawn pawnCurrent;
    public Pawn pawnClicked;
    public Pawn pawnToPlace;
    public Hex hexCurrent;

    public MapMaker mapMaker;
    public Unit selectedUnit;
    public MyPathFinder myPathFinder;

    // ray cast
    private Ray ray;
    private RaycastHit hitInfo;

    void Start ()
    {
        mapMaker = FindObjectOfType<MapMaker>().GetComponent<MapMaker>();	
	}
	
	void Update ()
    {
        // UI stuff
        #region
        //Debug.Log("Mouse Position: " + Input.mousePosition);
        // mouse over unity UI element
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/
        #endregion

        // raycast mouse pointer
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // raycast hit something..
        if (Physics.Raycast(ray, out hitInfo))
        {
            #region
            // get hit object collider
            ourHitObject = hitInfo.collider.transform.parent.gameObject;
            //print(ourHitObject = hitInfo.collider.transform.parent.gameObject);

            // over a hex..
            if (ourHitObject.transform.GetComponent<Hex>() != null)
            { 
                MouseClickHex(ourHitObject);
            }
            else if(ourHitObject.transform.GetComponent<Pawn>() != null)
            {
                MouseClickHex(ourHitObject);
            }
            // over a unit..
            else if (ourHitObject.transform.GetComponent<Unit>() != null)
            {
                MouseOverUnit(ourHitObject);
            }
            #endregion
        }
    }

    void MouseClickHex(GameObject ourHitObject)
    {
        // left click..
        if (Input.GetMouseButtonDown(0))
        {
            // MAP MAKING..
            #region
            if (mapMaker.mapMaking)
            {
                // hit empty hex
                if (ourHitObject.tag == "Hex Empty")
                {
                    SpawnHex(0);
                }
                else if (ourHitObject.tag == "Hex") 
                {
                    SpawnHex(1);
                }
                else if(ourHitObject.tag == "Half Hex")
                {
                    SpawnHex(2);
                }
            }
            
            // NOT MAPPING
            else
            {
                // clicked pawn
                if(ourHitObject.tag == "Pawn")
                {
                    // get pawn
                    pawnClicked = ourHitObject.GetComponent<Pawn>();
                    
                    // pawn not placed
                    if(!pawnClicked.isPlaced)
                    {
                        pawnToPlace = pawnClicked;
                    }
                    else
                    {
                        ClickPawn(pawnClicked.hexCurrent, pawnClicked);
                    }
                }

                // clicked HEX
                else if (ourHitObject.tag == "Hex")
                {
                    // get hex
                    hexCurrent = ourHitObject.GetComponent<Hex>();

                    // movement hex clicked
                    if (hexCurrent.adjacentMove)
                    {
                        MovePawn(hexCurrent);
                    }
                    // selecting pawn hex
                    else if (hexCurrent.pawnPresent != null)
                    {
                        ClickPawn(hexCurrent, hexCurrent.pawnPresent);
                    }

                    // placing pawn
                    if (pawnToPlace != null)
                    {
                        // set position to selected hex
                        pawnToPlace.transform.position = new Vector3(ourHitObject.transform.position.x, 
                            ourHitObject.transform.position.y + pawnToPlace.adjustmentHeight, 
                            ourHitObject.transform.position.z);

                        // set pawn to hex
                        ourHitObject.GetComponent<Hex>().pawnPresent = pawnToPlace;
                        // set hex to pawn
                        pawnToPlace.hexCurrent = ourHitObject.GetComponent<Hex>();
                        
                        // pawn is placed
                        pawnToPlace.isPlaced = true;
                        pawnToPlace = null;
                    }
                    
                    
                    else
                    {
                        //ourHitObject.GetComponent<Hex>().speed = speed;
                        //ourHitObject.GetComponent<Hex>().Pathfind();
                    }
                }
                else if (ourHitObject.tag == "Half Hex")
                {
                    SpawnHex(2);
                }
            }
            #endregion
        }

        // right click..
        if (Input.GetMouseButtonDown(1))
        {
            // MAP MAKING..
            #region
            if (mapMaker.mapMaking)
            {
                // hit empty hex
                if (ourHitObject.tag == "Hex Empty")
                {
                    DespawnHex(0);
                }
                else if (ourHitObject.tag == "Hex")
                {
                    DespawnHex(1);
                }
                else if (ourHitObject.tag == "Half Hex")
                {
                    DespawnHex(2);
                }
            }
            // NOT MAPPING
            else
            {

            }

            #endregion
        }
        // mesh renderer and FPS stuff
        #region        
        //MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();

        //ourHitObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        //ourHitObject.transform.parent.GetComponent<Hex>().GetNeighbours();

        //mr.materials[0].color = Color.red;

        //Ray fpsRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        #endregion
    }


    void ClickPawn(Hex Hex, Pawn Pawn)
    {
        // pawn is selected already
        if(pawnCurrent == Pawn)
        {
            DeselectPawn(Hex, pawnCurrent);
        }
        // pawn is NOT selected
        else
        {
            // select pawn
            pawnCurrent = Pawn;
            
            Hex.ClearPathfind();
            Hex.PathfindMovement(pawnCurrent.speedLeft + 1);
            Hex.PathfindAdjacentMovement();
        }
    }

    void DeselectPawn(Hex Hex, Pawn Pawn)
    {
        Hex.ClearPathfind();
        pawnCurrent = null;
    }

    void MovePawn(Hex DestinationHex)
    {
        int cost;
        // clear movement hex grid
        cost = DestinationHex.y - pawnCurrent.hexCurrent.y + 1;
        if(cost <= 0)
        {
            cost = 1;
        }
        pawnCurrent.speedLeft -= cost;
        pawnCurrent.hexCurrent.ClearPathfind();
        pawnCurrent.hexCurrent.speed = 0;
        pawnCurrent.hexCurrent.pawnPresent = null;

        // set pawn position
        pawnCurrent.transform.position = new Vector3(DestinationHex.transform.position.x,
            DestinationHex.transform.position.y + pawnCurrent.adjustmentHeight,
            DestinationHex.transform.position.z);

        // current pawn and hex set to each other
        pawnCurrent.hexCurrent = DestinationHex;
        DestinationHex.pawnPresent = pawnCurrent;

        // new pathfind hex grid
        DestinationHex.PathfindMovement(pawnCurrent.speedLeft + 1);
        DestinationHex.PathfindAdjacentMovement();
    }

    void SpawnHex(int emptyHexClicked)
    {
        // hit hex script
        Hex ourHitHexScript = ourHitObject.GetComponent<Hex>();
        
        // check for empty space
        // hex clicked..
        if (emptyHexClicked == 1)
        {
            #region
            // check height index..
            if (ourHitHexScript.y >= mapMaker.yTall - 1)
            {
                return;
            }
            // space above is null..
            else if (mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y + 1, ourHitHexScript.z, 0] != null)
            {
                return;
            }
            #endregion
        }
        // empty hex clicked..
        else if(emptyHexClicked == 2)
        {
            #region
            // q = 0..
            if (ourHitHexScript.q == 0)
            {
                // q 1 = null..
                if (mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 1] != null)
                {
                    return;
                }
            }
            // q = 1..
            else if(ourHitHexScript.q == 1)
            {
                // check height index..
                if (ourHitHexScript.y >= mapMaker.yTall - 1)
                {
                    return;
                }
                // y above = null..
                else if (mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y + 1, ourHitHexScript.z, 0] != null)
                {
                    return;
                }
            }
            #endregion
        }

        // instantiate new hex
        GameObject newHex = (GameObject)Instantiate(mapMaker.hexToInstantiate, ourHitObject.transform.position, Quaternion.identity);
        // get components
        Hex ourNewHexScript = newHex.transform.GetComponent<Hex>(); // new hex script
        // set array stuff
        ourNewHexScript.x = ourHitHexScript.x;  // set info new hex array x
        ourNewHexScript.y = ourHitHexScript.y;  // set info new hex array y
        ourNewHexScript.z = ourHitHexScript.z;  // set info new hex array z


        // half hex hit..
        if (emptyHexClicked == 2)
        {
            // placing hex on half hex..
            if(newHex.tag != "Half Hex")
            {
                Destroy(newHex);
                return;
            }
            // placing half hex on half hex..
            else
            {
                // hit hex is 0 q..
                if (ourHitHexScript.q == 0)
                {
                    ourNewHexScript.q++;
                }
                else if(ourHitHexScript.q == 1)
                {
                    ourNewHexScript.y++;
                }
                // real hex world position
                newHex.transform.position = new Vector3
                    (ourHitObject.transform.position.x, ourHitObject.transform.position.y + mapMaker.halfYOffset, ourHitObject.transform.position.z);
                // set new hex in array
                mapMaker.hexMapArray[ourNewHexScript.x, ourNewHexScript.y, ourNewHexScript.z, ourNewHexScript.q] = ourNewHexScript;
            }
        }

        // default hex hit..
        else if (emptyHexClicked == 0)
        {            
            // set new hex in array
            mapMaker.hexMapArray[ourNewHexScript.x, ourNewHexScript.y, ourNewHexScript.z, 0] = ourNewHexScript;

            // delete default hex
            Destroy(ourHitObject);
        }

        // real hex hit..
        else if (emptyHexClicked == 1)
        {
            // set info new hex array y
            ourNewHexScript.y++;

            // real hex world position
            newHex.transform.position = new Vector3
                (ourHitObject.transform.position.x, ourHitObject.transform.position.y + mapMaker.yOffset, ourHitObject.transform.position.z);
            // set new hex in array
            mapMaker.hexMapArray[ourNewHexScript.x, ourNewHexScript.y, ourNewHexScript.z, 0] = ourNewHexScript;

            Debug.Log(ourNewHexScript.x + "_" + ourNewHexScript.y + "_" + ourNewHexScript.z);
        }
    }

    void DespawnHex(int emptyHexClicked)
    {
        // get hit object
        Hex ourHitHexScript = ourHitObject.GetComponentInParent<Hex>();

        // empty hex hit..
        if (emptyHexClicked == 0)
        {
            Debug.Log("empty hit");
            return;
        }

        // real hex hit..
        else
        {
            // last real hex in its stack..
            if (ourHitHexScript.y == 1)
            {
                if((ourHitHexScript.q == 0 && mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 1] == null) ||
                    (ourHitHexScript.q == 1 && mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 0] == null))
                {
                    // instantiate empty tile
                    GameObject ourEmptyHex = Instantiate(mapMaker.defaultHexPrefab, 
                        mapMaker.hexPosArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 0].transform.position, Quaternion.identity);
                    Hex ourEmptyHexScript = ourEmptyHex.GetComponent<Hex>();
                    
                    // set empty hex array
                    ourEmptyHexScript.y = 1;                                                                                 // set empty hex array info y
                    ourEmptyHexScript.x = ourHitHexScript.x;                                                                 // set empty hex array info x
                    ourEmptyHexScript.z = ourHitHexScript.z;                                                                 // set empty hex array info z
                    mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 0] = ourEmptyHexScript;    // set empty hex array
                }
            }

            // not last real hex..
            else
            {
                // remove hit hex from array
                mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, ourHitHexScript.q] = null;
            }
            // destroy hit hex
            Destroy(ourHitHexScript.gameObject);
        }
    }

    void MouseOverUnit(GameObject ourHitObject)
    {
        selectedUnit = ourHitObject.transform.parent.GetComponent<Unit>();
        Debug.Log(selectedUnit);
    }

}
