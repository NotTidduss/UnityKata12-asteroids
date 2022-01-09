using UnityEngine;

public class Asteroids_PlayerPrefsMaster : MonoBehaviour
{
    // Reset all PlayerPrefs to a desirable value. Also, document them.
    public void resetAsteroidsPlayerPrefs() {
        // INT asteroids_highScore - the highest score ever achieved by the player
        if (PlayerPrefs.GetInt("asteroids_highScore") == 0)
            PlayerPrefs.SetInt("asteroids_highScore", 0);

        // INT asteroids_score - the score of the current game. Starts as 0.
        PlayerPrefs.SetInt("asteroids_score", 0);

        // INT asteroids_gameState - indicates if the state of the game. Mapped to enum Asteroids_GameState. 0 = GAME_RUNNING, 1 = GAME_PAUSED, 2 = GAME_OVER.
        PlayerPrefs.SetInt("asteroids_gameState", 0);
    }
}
