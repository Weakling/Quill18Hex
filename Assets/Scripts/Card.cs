using UnityEngine;
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
    public Image myPanel;

    // conditions
    [HideInInspector] public bool isClickable;
    //[HideInInspector] 
    public int numCopies;
    [HideInInspector] public int maxCopies;

    // enums
    public enum EnRace { Doggin, Dragon, Drow, Eladrin, Elf, Human, Kyrie, Marro, Nargrub, Orc, Soulborg, Troll, Trolticor, Viper };
    public enum EnClass { Agent, Arachnomancer, Archer, Archmage, Beast, Champion, Cow, Deathwalker, Guard, Hive, Hivelord, Hunter, King, Major, Mount, Scout, Stinger, Soldier, Warlord, Warrior, Wizard, Young };
    public enum EnTrait { Devout, Disciplined, Ferocious, Loyal, Merciful, Precise, Resolute, Terrifying, Tricky, Valiant, Wild };
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
    public int attNumberCard;
    
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
    
    // text
    public TextMeshProUGUI txtName, txtLife, txtMove, txtRange, txtAttack, txtDefense, txtCost;
    public TextMeshProUGUI txtType, txtRace, txtClass, txtSize, txtTrait;
    public TextMeshProUGUI txtAbility1, txtAbility2, txtAbility3, txtAbility4, txtAbility5;
    public TextMeshProUGUI txtFaction;

    

    private void Awake()
    {
        stateManager = FindObjectOfType<StateManager>();
        thisCard = this.GetComponent<Card>();
    }

    void Start ()
    {
        SetStatValues();
        SetTextFields();
        
        
        // set values
        isClickable = true;
        if(attType == EnType.UniqueHero || attType == EnType.UniqueSquad)
        {
            maxCopies = 1;
        }
        else
        {
            maxCopies = 3;
        }

        // is in army builder menu
        if(stateManager.armyBuilder)
        {
            armyBuilderMenu = FindObjectOfType<ArmyBuilderMenu>();
            deckListContent = FindObjectOfType<DeckListController>().gameObject;
        }

        //CreatePanel();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            print(this.transform.GetComponent<RectTransform>().sizeDelta.x);
        }
    }
    

    // set and create things
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

    void CreatePanel()
    {
        myPanel = new GameObject("myPanel").AddComponent<Image>();
        myPanel.transform.SetParent(this.transform);
        //myPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(230, 345);
        myPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, this.GetComponent<RectTransform>().sizeDelta.y);
        myPanel.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        myPanel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        myPanel.GetComponent<Image>().color = new Color32(0, 0, 0, 180);
        //myPanel.gameObject.SetActive(false);
    }


    // active/inactive
    public void SetCardActive()
    {
        isClickable = true;
        Destroy(myPanel);
        //myPanel.gameObject.SetActive(false);
    }

    public void SetCardInactive()
    {
        isClickable = false;
        deckListItem.isUnique = true;

        if(myPanel != null)
        {
            myPanel.gameObject.SetActive(true);
        }
        else
        { 
            CreatePanel();
        }
        
    }

    public void AddCardToDeck()
    {
        // add to deck list
        armyBuilderMenu._deckCurrent.Add(thisCard);

        // add visually to deck list
        deckListItem = Instantiate(deckListItemPrefab, deckListContent.transform);
        deckListItem.card = this.GetComponent<Card>();
        deckListItem.armyBuilder = armyBuilderMenu;
        deckListItem.txtMyText.text = this.attName;

        numCopies++;

        // check if at limit
        if (numCopies >= maxCopies)
        {
            SetCardInactive();
        }
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

                if(armyBuilderMenu.isBuildingDeck)
                {
                    AddCardToDeck();
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
