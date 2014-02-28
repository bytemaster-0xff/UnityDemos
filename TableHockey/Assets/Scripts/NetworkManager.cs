using System;
using UnityEngine;
using System.Linq;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	bool isPlayerTwo;
	bool _isReady = false;
	String CurrentState = "Starting Up";
	System.DateTime _started;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("alpha 0.1");
		_started = DateTime.Now;
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString() + " PLAYER TWO: " + isPlayerTwo.ToString() + " " + CurrentState);

	}

	void OnJoinedLobby(){
		Debug.Log ("We have joined the lobby!");
		CurrentState = "In Lobby";
		_isReady = false;
	
	}

	void Update()
	{
		if (PhotonNetwork.connectionState == ConnectionState.Connected) {
						if (!_isReady) {
								if ((DateTime.Now - _started).TotalSeconds < 5) {
										var rooms = PhotonNetwork.GetRoomList ();
										foreach (var room in rooms) {
												Debug.Log ("ROOM -> " + room.name);
												if (room.name == "KEVINS") {
														_isReady = true;
														PhotonNetwork.JoinRoom ("KEVINS");
														isPlayerTwo = true;
												}
										}
								} else {
										isPlayerTwo = false;
										_isReady = true;
										PhotonNetwork.CreateRoom ("KEVINS");

								}
						}
				}
	}

	void OnPhotonRandomJoinFailed(){
		isPlayerTwo = false;

		Debug.Log ("Could not join room, creating.");

		PhotonNetwork.CreateRoom ("KEVINS");
	}

	void OnJoinedRoom(){
		CurrentState = "READY!!";

		Debug.Log ("We have Joined the Room!");

		if (!isPlayerTwo) {
				GameObject PlayerOnePaddle = PhotonNetwork.Instantiate ("Paddle", new Vector3 (0, -2.5f, -10), Quaternion.identity, 0);
				PlayerOnePaddle.name = "PlayerOnePaddle";
				PaddleController playerOneController = PlayerOnePaddle.GetComponent<PaddleController> ();
				playerOneController.IsForThisPlayer = !isPlayerTwo;
				playerOneController.ThisPlayerIsPlayerTwo = false;
		} else {
				GameObject puck = PhotonNetwork.Instantiate ("Puck", new Vector3 (0, -2.5f, 0), Quaternion.identity, 0);

				GameObject PlayerTwoPaddle = PhotonNetwork.Instantiate ("Paddle", new Vector3 (0, -2.5f, 10), Quaternion.identity, 0);
				PlayerTwoPaddle.name = "PlayerTwoPaddle";
				var light = PlayerTwoPaddle.GetComponentInChildren<Light> ();
				light.color = Color.blue;

				PaddleController playerTwoController = PlayerTwoPaddle.GetComponent<PaddleController> ();
				playerTwoController.IsForThisPlayer = isPlayerTwo;
				playerTwoController.ThisPlayerIsPlayerTwo = true;

		}
	}
}
