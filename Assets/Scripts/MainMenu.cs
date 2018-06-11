using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text txtPlayerName;
    public Text txtInputNewName;
    private string nameStore;

    MapMaker mapMaker;

    public Canvas canMainMenu, canNameChangeMenu;


    private void Awake()
    {
        mapMaker = FindObjectOfType<MapMaker>();

    }

    private void Start()
    {
        txtPlayerName.text = PlayerPrefs.GetString("PlayerName", "player");
    }


    public void BTNMapping()
    {
        mapMaker.mapMaking = !mapMaker.mapMaking;
    }
    public void GOMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    public void GOLobby()
    {
        SceneManager.LoadScene(1);
    }

    public void GODeckBuilder()
    {
        SceneManager.LoadScene(2);
    }

    public void GOMapMaker()
    {
        SceneManager.LoadScene(2);
    }

    public void GOChangeName()
    {
        canMainMenu.gameObject.SetActive(false);
        canNameChangeMenu.gameObject.SetActive(true);
    }

    // confirm name change
    public void GONameChangeConfirm()
    {
        // store new name
        nameStore = txtInputNewName.text;
        txtInputNewName.text = "";

        // swap to main menu
        canMainMenu.gameObject.SetActive(true);
        canNameChangeMenu.gameObject.SetActive(false);

        // set new name
        txtPlayerName.text = nameStore;
        PlayerPrefs.SetString("PlayerName", nameStore);
        nameStore = "";
    }
}
