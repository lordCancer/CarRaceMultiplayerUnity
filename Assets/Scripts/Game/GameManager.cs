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
    public class GameManager
    {
        public static PlayerStatus playerStatus = PlayerStatus.nill;
    }

}
