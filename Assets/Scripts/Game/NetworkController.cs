using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Duge
{
	public class NetworkController : NetworkManager 
	{
		PlayerStatus status = GameManager.playerStatus;
		CarList chosenCar = GameManager.chosenCar;
		
		public GameObject car1, car2;
	
	// Use this for initialization
		void Start () {
		switch(status)
			{
				case PlayerStatus.nill:
					return;
				
				case PlayerStatus.host:
					StartHost();
					Debug.Log("Host Started");
					break;
				
				case PlayerStatus.client:
					StartClient();
					Debug.Log("Client Started");
					break;
			}
			
		}
	
	// Update is called once per frame
		void Update () {
		  	switch(chosenCar)
			{
				case CarList.car1:
					playerPrefab = car1;
					break;
				
				case CarList.car2:
					playerPrefab = car2;
					break;
				
				case CarList.nill:
					return;
			}
		
		
	 	}
	}
	
}
