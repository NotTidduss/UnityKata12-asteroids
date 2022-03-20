using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids_SceneMaster : MonoBehaviour
{
    public static void loadGameScene() => SceneManager.LoadScene("1x_Asteroids_Game");
}
