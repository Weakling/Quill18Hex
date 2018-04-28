using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(2);
        }
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
