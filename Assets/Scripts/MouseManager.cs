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

            if (Input.GetMouseButtonDown(0))
            {
                // over a hex..
                if (ourHitObject.transform.parent.GetComponent<Hex>() != null)
                {
                    Debug.Log("hex");
                    MouseClickHex(ourHitObject);
                }
                // over a unit..
                else if(ourHitObject.transform.parent.GetComponent<Unit>() != null)
                {
                    Debug.Log(ourHitObject.name);
                    MouseOverUnit(ourHitObject);
                }
            }
        }

    }

    void MouseClickHex(GameObject ourHitObject)
    {

        //MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();

        //ourHitObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        //ourHitObject.transform.parent.GetComponent<Hex>().GetNeighbours();
        if(ourHitObject.name == "default")
        {
            GameObject gO = (GameObject)Instantiate(mapMaker.tilesTypes[0].tileVisualPrefab, ourHitObject.transform.position, Quaternion.identity);
            gO.GetComponentInChildren<MeshRenderer>().materials[0].color = Color.green;
            Destroy(ourHitObject);
        }

        if(selectedUnit != null)
        {
            selectedUnit.destination = ourHitObject.transform.position;
        }

        //mr.materials[0].color = Color.red;

        //Ray fpsRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
    }

    void MouseOverUnit(GameObject ourHitObject)
    {
        selectedUnit = ourHitObject.transform.parent.GetComponent<Unit>();
        Debug.Log(selectedUnit);
    }
}
