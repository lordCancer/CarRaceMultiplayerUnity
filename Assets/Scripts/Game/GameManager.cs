using UnityEngine;
using UnityEngine.SceneManagement;

namespace Duge
{
    public enum PlayerStatus
    {
        host,
        client,
        nill
    }
    
    public enum CarList
    {
    	car1,
    	car2,
    	nill
    }
    
    public static class GameManager
    {
        public static PlayerStatus playerStatus = PlayerStatus.nill;
        public static CarList chosenCar = CarList.nill;
    }

}
