using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class DeckListItem : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public ArmyBuilderMenu armyBuilder;
    [HideInInspector] public Card card;
    [HideInInspector] public bool isUnique;

    public TextMeshProUGUI txtMyText;


    // detect click
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            armyBuilder._deckCurrent.Remove(card);

            if(card.numCopies >= card.maxCopies)
            {
                card.numCopies--;
                card.SetCardActive();
            }
            
            Destroy(this.gameObject);
        }

        else if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {

        }

        else if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            
        }
    }
}
