using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {


    // variables
    public bool mapMaking;

    // our hit object
    private GameObject ourHitObject;

    // hit hex

    // new hex

    // Game objects
    public MapMaker mapMaker;
    public Unit selectedUnit;

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

            // over a hex..
            if (ourHitObject.transform.GetComponent<Hex>() != null)
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
            if (mapMaking)
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
            #endregion
        }

        // right click..
        if (Input.GetMouseButtonDown(1))
        {
            // MAP MAKING..
            #region
            if (mapMaking)
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


        // empty hex hit..
        else if (emptyHexClicked == 0)
        {
            // renderer disable
            MeshRenderer ourHitMeshRenderer = ourHitObject.GetComponentInChildren<MeshRenderer>();
            MeshCollider ourHitMeshCollider = ourHitObject.GetComponentInChildren<MeshCollider>();
            ourHitMeshRenderer.enabled = false;
            ourHitMeshCollider.enabled = false;

            // set empty array
            ourHitHexScript.y--;                                                                                   // set empty hex array info y
            mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 0] = ourHitHexScript;    // set empty hex array

            // empty hex world position
            ourHitObject.transform.position = new Vector3
                (ourHitObject.transform.position.x, ourHitObject.transform.position.y - mapMaker.yOffset, ourHitObject.transform.position.z);
            // set new hex in array
            mapMaker.hexMapArray[ourNewHexScript.x, ourNewHexScript.y, ourNewHexScript.z, 0] = ourNewHexScript;
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
        // hit object
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
                    // get empty tile component
                    Hex ourEmptyHexScript = mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y - 1, ourHitHexScript.z, 0];
                    Debug.Log(ourHitHexScript.y - 1);
                    Debug.Log(ourHitHexScript.x);
                    Debug.Log(ourHitHexScript.z);
                    Debug.Log(mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y - 1, ourHitHexScript.z, 0]);
                    GameObject ourEmptyHex = ourEmptyHexScript.gameObject;
                    // set empty hex array
                    ourEmptyHexScript.y++;                                                                                   // set empty hex array info y
                    mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, 0] = ourEmptyHexScript;    // set empty hex array

                    // set empty hex position
                    ourEmptyHex.transform.position = new Vector3
                        (ourEmptyHex.transform.position.x, ourEmptyHex.transform.position.y + mapMaker.yOffset, ourEmptyHex.transform.position.z);

                    // renderer
                    MeshRenderer ourEmptyMeshRenderer = ourEmptyHexScript.GetComponentInChildren<MeshRenderer>();
                    MeshCollider ourEmptyMeshCollider = ourEmptyHexScript.GetComponentInChildren<MeshCollider>();
                    ourEmptyMeshRenderer.enabled = true;
                    ourEmptyMeshCollider.enabled = true;
                }
            }
            // not last real hex..
            else
            {
                mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, ourHitHexScript.q] = null;
                // debug
                //Debug.Log(mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z, ourHitHexScript.q]);
            }
            Destroy(ourHitHexScript.gameObject);
        }
    }

    void MouseOverUnit(GameObject ourHitObject)
    {
        selectedUnit = ourHitObject.transform.parent.GetComponent<Unit>();
        Debug.Log(selectedUnit);
    }

    void CheckForArrows()
    {

    }

    

    /*if (selectedUnit != null)
            {
                selectedUnit.destination = ourHitObject.transform.position;
            }*/
}
