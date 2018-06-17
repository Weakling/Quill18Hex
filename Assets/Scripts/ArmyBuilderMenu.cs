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

    public string[] _masterDeckList;

    private void Awake()
    {
        // set state manager
        FindObjectOfType<StateManager>().armyBuilder = true;

        // instantiate lists
        CreateLists();
    }

    
    void Start ()
    {
        // load resources
        LoadLists();
        //LoadCardGrid();
        GONecro();
        //SaveDeck();
        ReadDeckList();
	}


    private void Update()
    {
        
    }





    

    public void SaveDeck(string DeckName)
    {
        print("I wrote");
        
        // path of file
        //string path = Application.dataPath + "/Log.txt";
        string path = "Assets/Resources/decks/" + DeckName + ".txt";

        string content = "";

        foreach(Card c in _deckCurrent)
        {
            content = content + c.attNumberCard.ToString() + "\n";
        }

        File.WriteAllText(path, content);

        // save name to master deck list
        path = "Assets/Resources/decks/MasterDeckList.txt";
        content = DeckName + "\n";

        File.AppendAllText(path, content);

        // create file if not there
        /*if(!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }*/

        // content of the file
        //string content = "Login date: " + System.DateTime.Now + "\n";
    }

    public void ReadDeckList()
    {
        string path = "Assets/Resources/decks/MasterDeckList.txt";
        _masterDeckList = File.ReadAllLines(path);
        
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

    public void GOReadDeckList()
    {
        ReadDeckList();
    }

    public void GODeleteDeck()
    {

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
