using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using TMPro;



public class JoinGame : MonoBehaviour {

    List<GameObject> roomList = new List<GameObject>();

    [SerializeField] TextMeshProUGUI txtStatus;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform roomListParent;

    NetworkManager networkManager;

	void Start ()
    {
        // get network manager
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        // get rooms
        RefreshRoomList();
	}

    public void RefreshRoomList()
    {
        ClearRoomList();

        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        networkManager.matchMaker.ListMatches(0, 20, "", false, 0, 0, OnMatchList);
        txtStatus.text = "Loading..";
    }

    public void OnMatchList(bool Success, string extendedInfo, List<MatchInfoSnapshot> MatchList)
    {
        txtStatus.text = "";

        // failed
        if (!Success || MatchList == null)
        {
            txtStatus.text = "Couldn't get matches..";
            return;
        }        

        // fill list
        foreach(MatchInfoSnapshot match in MatchList)
        {
            GameObject roomListItemGO = Instantiate(roomListItemPrefab);
            roomListItemGO.transform.SetParent(roomListParent);

            RoomListItem roomListItem = roomListItemGO.GetComponent<RoomListItem>();
            if(roomListItem != null)
            {
                roomListItem.SetUp(match, JoinRoom);
            }

            roomList.Add(roomListItemGO);
        }

        if(roomList.Count == 0)
        {
            txtStatus.text = "No rooms at the moment..";
        }
    }

    void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }

        roomList.Clear();
    }

    public void JoinRoom(MatchInfoSnapshot Match)
    {
        Debug.Log("Joining " + Match.name);
        networkManager.matchMaker.JoinMatch(Match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        ClearRoomList();
        txtStatus.text = "Joining..";
    }
	
}
