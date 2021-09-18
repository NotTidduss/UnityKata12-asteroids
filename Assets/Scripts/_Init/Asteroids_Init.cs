using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids_Init : MonoBehaviour
{
    void Awake() {
        resetAsteroidsPlayerPrefs();
        SceneManager.LoadScene(PlayerPrefs.GetString("currentScene"));
    }

    private void resetAsteroidsPlayerPrefs() {
        /*
            permaPrefs
            
            INT asteroids_highScore - the highest score ever achieved by the player
        */

        // STRING currentScene - the name of the scene that was played last. Default "1_Asteroids".
        if (PlayerPrefs.GetString("currentScene") == "") PlayerPrefs.SetString("currentScene", "1_Asteroids");

        // INT asteroids_score - the score of the current game. Starts as 0.
        PlayerPrefs.SetInt("asteroids_score", 0);

        // INT asteroids_gameOver - indicates if the game is over. 0 = false, 1 = true.
        PlayerPrefs.SetInt("asteroids_gameOver", 0);
    }
}
