using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class Card : MonoBehaviour, IPointerClickHandler
{
    StateManager stateManager;
    ArmyBuilderMenu armyBuilderMenu;
    GameObject deckListContent;
    public DeckListItem deckListItemPrefab;
    DeckListItem deckListItem;

    [HideInInspector] public int numCopies;
    [HideInInspector] public int maxCopies;

    Card thisCard;

    public bool isUnique;
    public bool isSquad;
    public bool isClickable;

    public string attName;

    public string attType;
    public string attRace;
    public string attClass;
    public string attSizeBody;
    public int attSizeHeight;
    public string attTrait;
    

    public int statMaxLife;
    [HideInInspector] public int statCurrentLife;
    public int statMaxMove;
    [HideInInspector] public int statCurrentMove;
    public int statMaxRange;
    [HideInInspector] public int statCurrentRange;
    public int statMaxAttack;
    [HideInInspector] public int statCurrentAttack;
    public int statMaxDefense;
    [HideInInspector] public int statCurrentDefense;
    public int statCost;

    public string keyword1, keyword2, keyword3, keyword4, keyword5;
    public string faction;

    public TextMeshProUGUI txtName, txtLife, txtMove, txtRange, txtAttack, txtDefense, txtCost;
    public TextMeshProUGUI txtType, txtRace, txtClass, txtSize, txtTrait;
    public TextMeshProUGUI txtAbility1, txtAbility2, txtAbility3, txtAbility4, txtAbility5;
    public TextMeshProUGUI txtFaction;

    public Image myPanel;

    private void Awake()
    {
        stateManager = FindObjectOfType<StateManager>();
        thisCard = this.GetComponent<Card>();
    }

    void Start ()
    {
        SetStatValues();
        SetTextFields();

        isClickable = true;
        if(isUnique)
        {
            maxCopies = 1;
        }
        else
        {
            maxCopies = 3;
        }

        // in army builder
        if(stateManager.armyBuilder)
        {
            armyBuilderMenu = FindObjectOfType<ArmyBuilderMenu>();
            deckListContent = FindObjectOfType<DeckListController>().gameObject;
        }
	}
	

    void SetTextFields()
    {
        txtName.text = attName;
        txtLife.text = statCurrentLife.ToString();
        txtMove.text = statCurrentMove.ToString();
        txtRange.text = statCurrentRange.ToString();
        txtAttack.text = statCurrentAttack.ToString();
        txtDefense.text = statCurrentDefense.ToString();
        txtCost.text = statCost.ToString();

        txtType.text = attType;
        txtRace.text = attRace;
        txtClass.text = attClass;
        txtSize.text = attSizeBody + " " + attSizeHeight;
        txtTrait.text = attTrait;

        txtAbility1.text = keyword1;
        txtAbility2.text = keyword2;
        txtAbility3.text = keyword3;
        txtAbility4.text = keyword4;
        txtAbility5.text = keyword5;

        txtFaction.text = faction;
    }

    void SetStatValues()
    {
        statCurrentLife = statMaxLife;
        statCurrentMove = statMaxMove;
        statCurrentRange = statMaxRange;
        statCurrentAttack = statMaxAttack;
        statCurrentDefense = statMaxDefense;
    }

    public void SetCardActive()
    {
        isClickable = true;
        myPanel.gameObject.SetActive(false);
    }

    public void SetCardInactive()
    {
        isClickable = false;
        deckListItem.isUnique = true;
        myPanel.gameObject.SetActive(true);
    }

    // click
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            // in army builder
            if(stateManager.armyBuilder)
            {
                if (!isClickable)
                {
                    return;
                }

                // add to deck list
                armyBuilderMenu._deckCurrent.Add(thisCard);

                // add visually to deck list
                deckListItem = Instantiate(deckListItemPrefab, deckListContent.transform);
                deckListItem.card = this.GetComponent<Card>();
                deckListItem.armyBuilder = armyBuilderMenu;
                deckListItem.txtMyText.text = this.attName;

                numCopies++;

                // check if at limit
                if(numCopies >= maxCopies)
                {
                    SetCardInactive();
                }
            }
        }

        else if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {

        }

        else if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            armyBuilderMenu._deckCurrent.Remove(this.GetComponent<Card>());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }


}
