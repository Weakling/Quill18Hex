using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    // classes
    DirectoryManager directoryManager;

    // prefabs
    public MyButton mapButtonPrefab, deckButtonPrefab;

    // objects
    public Transform deckButtonParent, mapButtonParent;

    private void Awake()
    {
        directoryManager = FindObjectOfType<DirectoryManager>();
    }


    void Start ()
    {
        directoryManager.SetDirectories();
        directoryManager.ReadItemList(directoryManager.strMapDirectory, mapButtonPrefab, mapButtonParent);
        directoryManager.ReadItemList(directoryManager.strDeckDirectory, deckButtonPrefab, deckButtonParent);
	}


    void Update ()
    {
		
	}

    







}
