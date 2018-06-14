﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class Card : MonoBehaviour, IPointerClickHandler
{

    // other classes
    StateManager stateManager;
    ArmyBuilderMenu armyBuilderMenu;
    GameObject deckListContent;
    public DeckListItem deckListItemPrefab;
    DeckListItem deckListItem;

    // references
    Card thisCard;

    // conditions
    [HideInInspector] public bool isClickable;
    [HideInInspector] public int numCopies;
    [HideInInspector] public int maxCopies;

    // types
    public bool isUnique;
    public bool isSquad;
    public bool isHero;

    // enums
    public enum EnRace { Dragon, Drow, Elf, Marro, Nargrub, Orc, Soulborg, Troll, Trolticor, Viper };
    public enum EnClass { Arachnomancer, Archer, Beast, Champion, Cow, Deathwalker, Guard, Hive, Hivelord, Hunter, Major, Mount, Scout, Stinger, Warlord, Warrior, Young };
    public enum EnTrait { Devout, Ferocious, Loyal, Merciful, Precise, Terrifying, Tricky, Wild };
    public enum EnSize { Small, Medium, Large, Huge };
    public enum EnFaction { Necro, Tera, Phaze, Neutral };
    public enum EnType { Squad, Hero, UniqueSquad, UniqueHero };

    // attributes
    public EnRace attRace;
    public EnClass attClass;
    public EnTrait attTrait;
    public EnSize attSize;
    public EnFaction attFaction;
    public EnType attType;

    public string attName;
    public int attSizeHeight;
    public int attCost;
    
    // stats
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
    

    public string keyword1, keyword2, keyword3, keyword4, keyword5;
    

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
        if(isHero)
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

        CreatePanel();
    }
	

    void SetTextFields()
    {
        txtName.text = attName;
        txtLife.text = statCurrentLife.ToString();
        txtMove.text = statCurrentMove.ToString();
        txtRange.text = statCurrentRange.ToString();
        txtAttack.text = statCurrentAttack.ToString();
        txtDefense.text = statCurrentDefense.ToString();
        txtCost.text = attCost.ToString();


        if(attType == EnType.Squad)
        {
            txtType.text = "Squad";
        }
        else if(attType == EnType.UniqueHero)
        {
            txtType.text = "Unique Hero";
        }
        else if(attType == EnType.UniqueSquad)
        {
            txtType.text = "UniqueSquad";
        }
        else if(attType == EnType.Hero)
        {
            txtType.text = "Hero";
        }

        txtRace.text = attRace.ToString();
        txtClass.text = attClass.ToString();
        txtSize.text = attSize.ToString() + " " + attSizeHeight;
        txtTrait.text = attTrait.ToString();

        txtAbility1.text = keyword1;
        txtAbility2.text = keyword2;
        txtAbility3.text = keyword3;
        txtAbility4.text = keyword4;
        txtAbility5.text = keyword5;

        txtFaction.text = attFaction.ToString();
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

    void CreatePanel()
    {
        myPanel = new GameObject("myPanel").AddComponent<Image>();
        myPanel.transform.SetParent(this.transform);
        myPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 345);
        myPanel.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        myPanel.GetComponent<Image>().color = new Color32(0, 0, 0, 180);
        myPanel.gameObject.SetActive(false);
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
