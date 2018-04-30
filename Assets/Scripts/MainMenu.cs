using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    MapMaker mapMaker;


    private void Awake()
    {
        mapMaker = FindObjectOfType<MapMaker>();
    }




    public void BTNMapping()
    {
        mapMaker.mapMaking = !mapMaker.mapMaking;
    }
    public void GOMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GOTestGameplay()
    {
        SceneManager.LoadScene(1);
    }

    public void GOMapMaker()
    {
        SceneManager.LoadScene(2);
    }
}
