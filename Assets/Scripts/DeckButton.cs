using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DeckButton : MonoBehaviour, IPointerClickHandler {

    public TextMeshProUGUI txtName;
    public ArmyBuilderMenu armyBuilderMenu;

	
	void Start ()
    {
		
	}
	


    // detect click
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            armyBuilderMenu.LoadDeck(this.txtName.text);
        }

        else if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {

        }

        else if (pointerEventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}
