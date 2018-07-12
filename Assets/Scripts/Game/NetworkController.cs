using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Duge
{
	[System.Serializable]
	public class CarDetail
	{
		public GameObject carPrefab;
		public Material[]   carMaterial;
	}
	
	public class NetworkController : NetworkManager 
	{
		PlayerStatus status = GameManager.playerStatus;
		CarList chosenCar = GameManager.chosenCar;
		
		public List<CarDetail> carDetail;
	
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
		  			playerPrefab = carDetail[0].carPrefab;
					break;
				
				case CarList.car2:
					playerPrefab = carDetail[0].carPrefab;
					break;
				
				case CarList.nill:
					return;
			}
		
		
	 	}
	}
	
}
