using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Duge
{
    public enum CarType
    {
        red,
        black
    }

    public class NetworkController : NetworkManager
    {
        public GameObject mainMenu, carSelectMenu;
        public CarType CarType { get; set; }
    

        public void OnSelectCar1()
        {
            CarType = CarType.red;
            carSelectMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        public void OnSelectCar2()
        {
            CarType = CarType.black;
            carSelectMenu.SetActive(false);
            mainMenu.SetActive(true);
        }

        private void SetPort(int portNum)
        {
            networkPort = portNum;
        }

        private void SetIPAddress()
        {
            networkAddress = "localhost";
        }

        public void OnSelectHostBtn()
        {
            SetIPAddress();
            SetPort(7777);
            StartHost();
        }
        public void OnSelectClientBtn()
        {
            SetPort(7777);
            StartClient();
        }
    }
}
