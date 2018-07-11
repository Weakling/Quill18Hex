using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using TMPro;

public class RoomListItem : MonoBehaviour {

    public delegate void JoinRoomDelegate(MatchInfoSnapshot Match);
    private JoinRoomDelegate joinRoomCallback;

    [SerializeField] TextMeshProUGUI txtRoomName;

    MatchInfoSnapshot match;

	public void SetUp(MatchInfoSnapshot Match, JoinRoomDelegate JoinRoomCallback)
    {
        match = Match;
        joinRoomCallback = JoinRoomCallback;

        txtRoomName.text = match.name + " (" + match.currentSize + "/" + match.maxSize + ")";
    }

    public void JoinRoom()
    {
        joinRoomCallback.Invoke(match);
    }
}
