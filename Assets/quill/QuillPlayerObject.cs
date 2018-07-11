using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuillPlayerObject : NetworkBehaviour {

    public GameObject playerUnitPrefab;


    void Start()
    {
        if (isLocalPlayer == false)
        {
            return;

        }

        print("I am spawning");
        CmdSpawnMyUnit();
    }


    void Update()
    {
        if (isLocalPlayer == false)
        {
            return;
        }


    }


    [Command]
    void CmdSpawnMyUnit()
    {
        GameObject go = Instantiate(playerUnitPrefab);

        NetworkServer.Spawn(go);
    }
}
