using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DirectoryManager : MonoBehaviour {



    public string strDeckDirectory = Application.persistentDataPath + "/decks/";
    public string strMapDirectory = Application.persistentDataPath + "/maps/";

    string strMasterDeckListDir, strMasterMapListDir;


    // set paths for deck and map dir
    // create folders/files if not there
    public void SetDirectories()
    {
        // set master deck list dir
        strMasterDeckListDir = strDeckDirectory + "/masterdecklist.txt";

        // create directory if it doesn't exist
        if (!Directory.Exists(strDeckDirectory))
        {
            Directory.CreateDirectory(strDeckDirectory);
            Debug.LogError("created deck directory");
        }
        // create master deck list file if it doesn't exist
        if (!File.Exists(strMasterDeckListDir))
        {
            File.WriteAllText(strMasterDeckListDir, "");
            Debug.LogError("created deck list");
        }


        // set master map list dir
        strMasterMapListDir = strMapDirectory + "/mastermaplist.txt";

        // create directory if it doesn't exist
        if (!Directory.Exists(strMapDirectory))
        {
            Directory.CreateDirectory(strMapDirectory);
            Debug.LogError("created deck directory");
        }
        // create master deck list file if it doesn't exist
        if (!File.Exists(strMasterMapListDir))
        {
            File.WriteAllText(strMasterMapListDir, "");
            Debug.LogError("created map list");
        }
    }


    public void ReadItemList(string Path, MyButton ButtonPrefab, Transform ItemParent)
    {
        string path = Path;
        string[] _masterItemList = File.ReadAllLines(path);

        if (_masterItemList.Length < 1)
        {
            return;
        }
        ClearGenericButtons(ItemParent);

        foreach (string s in _masterItemList)
        {
            MyButton go = Instantiate(ButtonPrefab, ItemParent);
            go.txtName.text = s;
            go.name = "map btn " + s;
        }
    }


    void ClearGenericButtons(Transform ItemParent)
    {
        foreach (Transform child in ItemParent)
        {
            Destroy(child.gameObject);
        }
    }


}
