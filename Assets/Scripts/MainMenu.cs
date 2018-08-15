using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour {

    // vars
    private string nameStore;


    // classes
    public TextMeshProUGUI txtPlayerName;
    public Text txtInputNewName;
    MapMaker mapMaker;

    public Canvas canMainMenu, canNameChangeMenu;


    private void Start()
    {
        txtPlayerName.text = SavePPManager.GetString(SavePPManager.PrefString.PlayerName.ToString(), "player");
    }


    public void BTNMapping()
    {
        mapMaker.mapMaking = !mapMaker.mapMaking;
    }


    // change scene buttons:

    public void GOMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GOLobby()
    {
        SceneManager.LoadScene(4);
    }

    public void GODeckBuilder()
    {
        SceneManager.LoadScene(2);
    }

    public void GOMapMaker()
    {
        SceneManager.LoadScene(3);
    }


    // name change:
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
        SavePPManager.SetString(SavePPManager.PrefString.PlayerName.ToString(), nameStore);
        nameStore = "";
    }
}