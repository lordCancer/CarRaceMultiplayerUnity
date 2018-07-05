using UnityEngine.SceneManagement;
using UnityEngine;

namespace Duge
{
    public class Scene : MonoBehaviour
    {

        public void ChangeSceneTo(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void Host()
        {
            GameManager.playerStatus = PlayerStatus.host;
            SceneManager.LoadScene("GamePlay");
        }

        public void Client()
        {
            GameManager.playerStatus = PlayerStatus.client;
            SceneManager.LoadScene("GamePlay");
        }
    }

}
