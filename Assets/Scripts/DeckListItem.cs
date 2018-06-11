using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckListItem : MonoBehaviour {

    [SerializeField]
    private Text txtMyText;

    public DeckListController deckListController;

    private string myTextString;

    public void SetText(string textString)
    {
        myTextString = textString;
        txtMyText.text = textString;
    }

    public void OnClick()
    {
        deckListController.ButtonClicked(myTextString);
    }
}
