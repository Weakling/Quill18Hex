using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    // classes
    DirectoryManager directoryManager;

    // prefabs
    public MyButton deckButtonPrefab, mapButtonPrefab;

    // objects
    public Transform deckButtonParent, mapButtonParent;

    private void Awake()
    {
        directoryManager = FindObjectOfType<DirectoryManager>();
    }


    void Start ()
    {
        directoryManager.SetDirectories();
        directoryManager.ReadItemList(directoryManager.strMasterMapListDir, mapButtonPrefab, mapButtonParent);
        //directoryManager.ReadItemList(directoryManager.strMasterDeckListDir, deckButtonPrefab, deckButtonParent);
	}


    void Update ()
    {
		
	}

    







}
