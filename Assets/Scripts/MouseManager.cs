using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {


    public bool mapMaking;

	// Use this for initialization
	void Start () {
		
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
                    MouseOverHex(ourHitObject);
                }
            }

        }

    }

    void MouseOverHex(GameObject ourHitObject)
    {

        //MeshRenderer mr = ourHitObject.GetComponentInChildren<MeshRenderer>();
        ourHitObject.GetComponent<MeshRenderer>().materials[0].color = Color.red;
        ourHitObject.transform.parent.GetComponent<Hex>().GetNeighbours();

        //mr.materials[0].color = Color.red;

        //Ray fpsRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

    }
}
