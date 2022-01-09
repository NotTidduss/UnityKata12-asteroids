using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids_System : MonoBehaviour
{
    [Header ("Global Game Settings")]
    public float checkForGameOverCooldown = 3f;


    [Header ("Space Ship Settings")]
    public float defaultMovementSpeed = 0.02f;
    public float defaultRotationSpeed = 0.05f;


    [Header ("Obstacle Settings")]
    public float obstacleSpawnPositionX = 55f;
    public float obstacleSpawnPositionZ = 31f;
    public float obstacleSpawnCooldown = 5f;


#region Keybindings
    [Header ("Keybinds")]
    public KeyCode inputAccelerate = KeyCode.UpArrow;
    public KeyCode inputBrake = KeyCode.DownArrow;
    public KeyCode inputRotateRight = KeyCode.RightArrow;
    public KeyCode inputRotateLeft = KeyCode.LeftArrow;
    public KeyCode inputPause = KeyCode.Space;
#endregion

#region SceneManagement
    [Header ("Scene Names")]
    public string gameSceneName = "1x_Asteroids_Game";


    public void loadGameScene() => SceneManager.LoadScene(gameSceneName);
#endregion

#region PlayerPrefsManagement
    [Header ("PlayerPrefsMaster Reference")]
    public Asteroids_PlayerPrefsMaster ppmRef;


    public void resetPlayerPrefs() => ppmRef.resetAsteroidsPlayerPrefs();
#endregion
}

// GameState used to communicate pausing and game over events between scenes. Mapped to PlayerPref asteroids_gameState.
public enum Asteroids_GameState {
    GAME_RUNNING,
    GAME_PAUSED,
    GAME_OVER
}

// SpaceShipControl used to communicate manouvres to currently selected ship.
public enum Asteroids_SpaceShipControl {
    ACCELERATE,
    BRAKE,
    ROTATE_LEFT,
    ROTATE_RIGHT
}