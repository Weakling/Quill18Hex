using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class ArmyBuilderMenu : MonoBehaviour {

    public List<Card> _cardsNeutral, _cardsNecro, _cardsPhaze, _cardsTera;
    public List<Card> _deckCurrent;

    public Transform deckGridNecro, deckGridTera, deckGridPhaze, deckGridNeutral;

    public Text txtDeckNameInput;

    // classes
    CardCreator cardCreator;

    // deck storage
    public string[] _masterDeckList;
    string strDeckDir, strMasterDeckDir;
    public DeckButton deckButtonPrefab;
    public Transform deckButtonParent;

    private void Awake()
    {
        // set state manager
        FindObjectOfType<StateManager>().armyBuilder = true;

        // instantiate lists
        CreateLists();
    }

    
    void Start ()
    {
        // set dir
        strDeckDir = "Assets/Resources/decks/";
        strMasterDeckDir = "Assets/Resources/decks/MasterDeckList.txt";

        // get classes
        cardCreator = this.GetComponent<CardCreator>();

        // load resources
        LoadLists();
        //LoadCardGrid();
        GONecro();
	}


    private void Update()
    {
        
    }





    

    public void SaveDeck(string DeckName)
    {
        // path of file
        string path = strDeckDir + DeckName + ".txt";
        string content = "";
        string[] _deckList;

        // set content
        foreach(Card c in _deckCurrent)
        {
            content = content + c.attNumberCard.ToString() + "\n";
        }

        // write content
        File.WriteAllText(path, content);

        // check deck list for existing
        path = strMasterDeckDir;
        _deckList = File.ReadAllLines(path);
        foreach(string s in _deckList)
        {
            if(s == DeckName)
            {
                return;
            }
        }

        // save new name to deck list
        content = DeckName + "\n";
        File.AppendAllText(path, content);
    }

    public void LoadDeck(string DeckName)
    {
        string path = strDeckDir + DeckName + ".txt";

        foreach (string s in _masterDeckList)
        {
            cardCreator.CreateCard(int.Parse(s));
        }
    }

    public void ReadDeckList()
    {
        string path = strMasterDeckDir;
        _masterDeckList = File.ReadAllLines(path);
        
        foreach(string s in _masterDeckList)
        {
            DeckButton go = Instantiate(deckButtonPrefab, deckButtonParent);
            go.txtName.text = s;
            go.name = "btn " + s;
            go.armyBuilderMenu = this.GetComponent<ArmyBuilderMenu>();
        }
    }

    public void DeleteDeck(string DeckName)
    { 
        // delete txt
        string path = strDeckDir + DeckName + ".txt";
        File.Delete(path);

        // delete from deck list
        path = strMasterDeckDir;
        string[] _deckList = File.ReadAllLines(path);
        List<string> _newDeckList = new List<string>();
        foreach (string s in _deckList)
        {
            if (s != DeckName)
            {
                _newDeckList.Add(s);
            }
        }
        File.WriteAllLines(path, _newDeckList.ToArray());
    }

    public void LoadCardGrid()
    {
        for (int i = 0; i < _cardsNecro.Count; i++)
        {
            Instantiate(_cardsNecro[i], deckGridNecro);
        }

        for (int i = 0; i < _cardsTera.Count; i++)
        {
            Instantiate(_cardsTera[i], deckGridTera);
        }

        for (int i = 0; i < _cardsPhaze.Count; i++)
        {
            Instantiate(_cardsPhaze[i], deckGridPhaze);
        }

        for (int i = 0; i < _cardsNeutral.Count; i++)
        {
            Instantiate(_cardsNeutral[i], deckGridNeutral);
        }

    }




    void CreateLists()
    {
        _cardsNeutral = new List<Card>();
        _cardsNecro = new List<Card>();
        _cardsPhaze = new List<Card>();
        _cardsTera = new List<Card>();

        _deckCurrent = new List<Card>();
    }

    void LoadLists()
    {
        _cardsNeutral = Resources.LoadAll("ready/neutral", typeof(Card)).Cast<Card>().ToList();
        _cardsNecro = Resources.LoadAll("ready/necro", typeof(Card)).Cast<Card>().ToList();
        _cardsPhaze = Resources.LoadAll("ready/phaze", typeof(Card)).Cast<Card>().ToList();
        _cardsTera = Resources.LoadAll("ready/tera", typeof(Card)).Cast<Card>().ToList();
    }

    public void GOSaveDeck()
    {
        if (txtDeckNameInput.text.Any(char.IsLetterOrDigit))
        {
            SaveDeck(txtDeckNameInput.text);
        }
    }

    public void GOLoadDeck()
    {
        if (txtDeckNameInput.text.Any(char.IsLetterOrDigit))
        {
            LoadDeck(txtDeckNameInput.text);
        }
    }

    public void GOReadDeckList()
    {
        ReadDeckList();
    }

    public void GODeleteDeck()
    {
        DeleteDeck(txtDeckNameInput.text);
    }

    public void GONecro()
    {
        deckGridNecro.gameObject.SetActive(true);
        deckGridTera.gameObject.SetActive(false);
        deckGridPhaze.gameObject.SetActive(false);
        deckGridNeutral.gameObject.SetActive(false);
    }

    public void GOTera()
    {
        deckGridTera.gameObject.SetActive(true);
        deckGridNecro.gameObject.SetActive(false);
        deckGridPhaze.gameObject.SetActive(false);
        deckGridNeutral.gameObject.SetActive(false);
    }

    public void GOPhaze()
    {
        deckGridPhaze.gameObject.SetActive(true);
        deckGridTera.gameObject.SetActive(false);
        deckGridNecro.gameObject.SetActive(false);
        deckGridNeutral.gameObject.SetActive(false);
    }

    public void GONeutral()
    {
        deckGridNeutral.gameObject.SetActive(true);
        deckGridPhaze.gameObject.SetActive(false);
        deckGridTera.gameObject.SetActive(false);
        deckGridNecro.gameObject.SetActive(false);
    }

    public void GOMainMenu()
    {
        print("moop");
        SceneManager.LoadScene(0);
    }
}

//string path = Application.dataPath + "/Log.txt";
// create file if not there
/*if(!File.Exists(path))
{
    File.WriteAllText(path, "Login log \n\n");
}*/

// content of the file
//string content = "Login date: " + System.DateTime.Now + "\n";