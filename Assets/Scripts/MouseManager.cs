using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {


    public bool mapMaking;
    public MapMaker mapMaker;

    public Unit selectedUnit;

	void Start ()
    {
        mapMaker = FindObjectOfType<MapMaker>().GetComponent<MapMaker>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Mouse Position: " + Input.mousePosition);
        // mouse over unity UI element
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            //Debug.Log("Raycast hit: " + hitInfo.collider.transform.parent.name);
            //Debug.Log("hit something :" + hitInfo.collider.transform.parent.name);
            // over a hex..
            if (ourHitObject.transform.parent.GetComponent<Hex>() != null)
            {
                //Debug.Log("hex");
                MouseClickHex(ourHitObject);
            }
            // over a unit..
            else if (ourHitObject.transform.parent.GetComponent<Unit>() != null)
            {
                //Debug.Log(ourHitObject.name);
                MouseOverUnit(ourHitObject);
            }



        }

    }

    void MouseClickHex(GameObject ourHitObject)
    {
        // left click..
        if (Input.GetMouseButtonDown(0))
        {
            // MAP MAKING..
            if (mapMaking)
            {
                // hit default hex
                if (ourHitObject.name == "default")
                {
                    // instantiate new tile
                    GameObject newGo = (GameObject)Instantiate(mapMaker.tilesTypes[0].tileVisualPrefab, ourHitObject.transform.position, Quaternion.identity);
                    // get components
                    Hex newGoHexScript = newGo.transform.GetComponent<Hex>();
                    Hex ourHitEmptyHexScript = ourHitObject.GetComponentInParent<Hex>();

                    // set array stuff
                    newGoHexScript.x = ourHitEmptyHexScript.x;
                    newGoHexScript.y = ourHitEmptyHexScript.y;
                    newGoHexScript.z = ourHitEmptyHexScript.z;

                    ourHitEmptyHexScript.y = ourHitEmptyHexScript.y + 1;
                    mapMaker.hexMapArray[newGoHexScript.x, newGoHexScript.y, newGoHexScript.z] = newGoHexScript;
                    mapMaker.hexMapArray[ourHitEmptyHexScript.x, ourHitEmptyHexScript.y, ourHitEmptyHexScript.z] = ourHitEmptyHexScript;


                    ourHitObject.transform.parent.position = new Vector3(ourHitObject.transform.parent.position.x, ourHitObject.transform.parent.position.y + mapMaker.yOffset, ourHitObject.transform.parent.position.z);     
                                                                           
                }
            }


            if (selectedUnit != null)
            {
                selectedUnit.destination = ourHitObject.transform.position;
            }
        }
        // right click..
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Moo you");
            // MAP MAKING..
            if (mapMaking)
            {
                if (ourHitObject.name == "default")
                {
                    // get empty tile component
                    Hex ourHitEmptyHexScript = ourHitObject.GetComponentInParent<Hex>();
                    ourHitEmptyHexScript.y = ourHitEmptyHexScript.y - 1;

                    Destroy(mapMaker.hexMapArray[ourHitEmptyHexScript.x, ourHitEmptyHexScript.y, ourHitEmptyHexScript.z].gameObject);
                    mapMaker.hexMapArray[ourHitEmptyHexScript.x, ourHitEmptyHexScript.y, ourHitEmptyHexScript.z] = ourHitEmptyHexScript;
                    ourHitEmptyHexScript.transform.position = new Vector3 (ourHitEmptyHexScript.transform.position.x, ourHitEmptyHexScript.y * mapMaker.yOffset, ourHitEmptyHexScript.transform.position.z);
                }
            }
        }
        //MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();

        //ourHitObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        //ourHitObject.transform.parent.GetComponent<Hex>().GetNeighbours();

        //mr.materials[0].color = Color.red;

        //Ray fpsRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
    }

    void MouseOverUnit(GameObject ourHitObject)
    {
        selectedUnit = ourHitObject.transform.parent.GetComponent<Unit>();
        Debug.Log(selectedUnit);
    }
}
