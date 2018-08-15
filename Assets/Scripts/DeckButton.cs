using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

// click to load deck

    // if this doesn't click, I inherit now
public class DeckButton : MyButton, IPointerClickHandler {

    // objects/classes
    public ArmyBuilderMenu armyBuilderMenu;


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
