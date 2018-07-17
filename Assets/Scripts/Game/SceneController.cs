using UnityEngine.SceneManagement;
using UnityEngine;

namespace Duge
{
    public class SceneController : MonoBehaviour
    {

        public void ChangeSceneTo(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Host()
        {
            GameManager.playerStatus = PlayerStatus.host;
            SceneManager.LoadScene("Car Select");
        }

        public void Client()
        {
            GameManager.playerStatus = PlayerStatus.client;
            SceneManager.LoadScene("Car Select");
        }
        
        public void ChooseCar1()
        {
        	GameManager.chosenCar = CarList.car1;
        	SceneManager.LoadScene("GamePlay");
        }
        
        public void ChooseCar2()
        {
        	GameManager.chosenCar = CarList.car1;
        	SceneManager.LoadScene("GamePlay");
        }        
        
    }

}
