﻿using UnityEngine;
using System.Collections;
using System;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization

    public GameObject playerPrefab;

	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
	// Update is called once per frame
	/*
	void Update () {
	
	}
	*/
	private const string roomName = "RoomName";
	private RoomInfo[] roomsList;
	
	void OnGUI()
	{
		if (!PhotonNetwork.connected)
		{
			GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		}
		else if (PhotonNetwork.room == null)
		{
			// Create Room
			if (GUI.Button(new Rect(350, 0, 150, 25), "Start Server"))
				PhotonNetwork.CreateRoom(roomName + Guid.NewGuid().ToString("N"), true, true, 5);
			
			// Join Room
			if (roomsList != null)
			{
				for (int i = 0; i < roomsList.Length; i++)
				{
					if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join " + roomsList[i].name))
						PhotonNetwork.JoinRoom(roomsList[i].name);
				}
			}
		}
	}
	
	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}

	void OnJoinedRoom()
	{
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 20, 0), Quaternion.identity,
            0);

		Debug.Log("Connected to Room");
	}
}
