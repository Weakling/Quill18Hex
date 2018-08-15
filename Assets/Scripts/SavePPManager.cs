using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePPManager : MonoBehaviour {


    public enum PrefString { PlayerName };



    private void Start()
    {
        
    }

    public static string GetString(string SavedItem, string DefaultValue)
    {
        string String = PlayerPrefs.GetString(SavedItem, DefaultValue);

        return String;
    }

    public static void SetString(string SavedItem, string NewValue)
    {
        PlayerPrefs.SetString(SavedItem, NewValue);
    }
}
