using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids_System : MonoBehaviour
{
    [Header ("Keybinds")]
    public KeyCode inputMoveForward = KeyCode.UpArrow;
    public KeyCode inputMoveBackward = KeyCode.DownArrow;
    public KeyCode inputRotateRight = KeyCode.RightArrow;
    public KeyCode inputRotateLeft = KeyCode.LeftArrow;
    public KeyCode inputPause = KeyCode.Space;

    [Header ("Scene Names")]
    public string initSceneName = "0_Init";
    public string asteroidSceneName = "1_Asteroids";

    [Header ("Global Game Settings")]
    public float checkForGameOverCooldown = 3f;

    [Header ("Space Ship Settings")]
    public float defaultMovementSpeed = 0.02f;
    public float defaultRotationSpeed = 0.5f;

    [Header ("Obstacle Settings")]
    public float obstacleSpawnPositionX = 55f;
    public float obstacleSpawnPositionZ = 31f;
    public float obstacleSpawnCooldown = 5f;

    public void loadInitScene() => SceneManager.LoadScene(initSceneName);
}
