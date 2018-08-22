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
    }

}
