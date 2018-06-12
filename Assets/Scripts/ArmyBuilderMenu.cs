using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class ArmyBuilderMenu : MonoBehaviour {

    public List<Card> _cardsNeutral, _cardsNecro, _cardsPhaze, _cardsTera;
    public List<Card> _deckCurrent;

    public Transform deckGridNecro, deckGridTera, deckGridPhaze, deckGridNeutral;

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
        LoadCardGrid();
        GONecro();
	}


    private void Update()
    {
        
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
