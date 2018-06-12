using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour {

    public GameObject textObject;

	// hide or show text (opposite of its current state)
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Equals))
        {
            if(textObject.activeSelf)
            {
                textObject.SetActive(false);
            }
            else
            {
                textObject.SetActive(true);
            }
        }	
	}

    
}
