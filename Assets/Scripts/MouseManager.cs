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
                    SpawnHex(true);
                }
                else if (ourHitObject.tag == "Hex")
                {
                    SpawnHex(false);
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
                    DespawnHex(true);
                }
                else if (ourHitObject.tag == "Hex")
                {
                    DespawnHex(false);
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

    void SpawnHex(bool emptyHexClicked)
    {
        // instantiate new hex
        GameObject newHex = (GameObject)Instantiate(mapMaker.hexToInstantiate, ourHitObject.transform.position, Quaternion.identity);
        // get components
        Hex ourNewHexScript = newHex.transform.GetComponent<Hex>(); // new hex script
        Hex ourHitHexScript = ourHitObject.GetComponent<Hex>();     // hit hex script

        // set array stuff
        ourNewHexScript.x = ourHitHexScript.x;  // set info new hex array x
        ourNewHexScript.y = ourHitHexScript.y;  // set info new hex array y
        ourNewHexScript.z = ourHitHexScript.z;  // set info new hex array z
        
        // empty hex hit..
        if (emptyHexClicked)
        {
            // renderer disable
            MeshRenderer ourHitMeshRenderer = ourHitObject.GetComponentInChildren<MeshRenderer>();
            ourHitMeshRenderer.enabled = false;

            // set empty array
            ourHitHexScript.y--;                                                                                // set empty hex array info y
            mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z] = ourHitHexScript;    // set empty hex array

            // empty hex world position
            ourHitObject.transform.position = new Vector3
                (ourHitObject.transform.position.x, ourHitObject.transform.position.y - mapMaker.yOffset, ourHitObject.transform.position.z);
        }
        // real hex hit..
        else
        {
            // set info new hex array y
            ourNewHexScript.y++;  

            // real hex world position
            newHex.transform.position = new Vector3
                (ourHitObject.transform.position.x, ourHitObject.transform.position.y + mapMaker.yOffset, ourHitObject.transform.position.z);
        }
        mapMaker.hexMapArray[ourNewHexScript.x, ourNewHexScript.y, ourNewHexScript.z] = ourNewHexScript;
        Debug.Log(ourNewHexScript.x + "_" + ourNewHexScript.y + "_" + ourNewHexScript.z);

    }

    void DespawnHex(bool emptyHexClicked)
    {
        // empty hex hit
        if (emptyHexClicked)
        {
            Debug.Log("empty hit");
            return;
        }
        // real hex hit
        else
        {  
            // hit object
            Hex ourHitHexScript = ourHitObject.GetComponentInParent<Hex>();


            //Debug.Log(ourHitHexScript.x + "_" + ourHitHexScript.y + "_" + ourHitHexScript.z);
            //Debug.Log(mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z]);
            
            // last real hex in its stack
            if (ourHitHexScript.y == 1)
            {
                // get empty tile component
                Hex ourEmptyHexScript = mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y - 1, ourHitHexScript.z];
                GameObject ourEmptyHex = ourEmptyHexScript.gameObject;
                // set empty hex array
                ourEmptyHexScript.y++;                                                                              // set empty hex array info y
                mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z] = ourEmptyHexScript;    // set empty hex array

                // set empty hex position
                ourEmptyHex.transform.position = new Vector3 
                    (ourEmptyHex.transform.position.x, ourEmptyHex.transform.position.y + mapMaker.yOffset, ourEmptyHex.transform.position.z);

                // renderer
                MeshRenderer ourEmptyMeshRenderer = ourEmptyHexScript.GetComponentInChildren<MeshRenderer>();
                ourEmptyMeshRenderer.enabled = true;
            }
            else
            {
                mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z] = null;
            }
            Destroy(ourHitHexScript.gameObject);

            
            /*if (ourHitHexScript == mapMaker.hexMapArray[ourHitHexScript.x, ourHitHexScript.y, ourHitHexScript.z])
            {
                Debug.Log("hit low");
            }*/
            
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
