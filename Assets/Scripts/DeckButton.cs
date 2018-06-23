using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DeckButton : MonoBehaviour, IPointerClickHandler {

    public TextMeshProUGUI txtName;


	
	void Start ()
    {
		
	}
	


    // detect click
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            print("Clickeme");
        }

        else if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {

        }

        else if (pointerEventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}
