using System.Collections;
using UnityEngine;

public class Asteroids_Master : MonoBehaviour
{
    [Header ("Scene References")]
    public Asteroids_System sys;
    [SerializeField] private Asteroids_UI ui;
    [SerializeField] private Transform playfield;

    [Header ("Prefab References")]
    [SerializeField] private GameObject[] spaceShipPrefabs;
    [SerializeField] private GameObject[] obstaclePrefabs;

    // private variables
    private GameObject spaceShipObject;
    private GameObject nextObstacle;
    private Asteroids_SpaceShip spaceShip;
    private bool isPaused;

    void Start() {
        // prepare private variables
        isPaused = false;

        // prepare PlayerPrefs
        PlayerPrefs.SetString("currentScene", sys.asteroidSceneName);

        // prepare game
        ui.initialize();

        // TODO: implement space ship selection and update space ship fetching here
        spaceShipObject = Instantiate(spaceShipPrefabs[0], playfield);
        spaceShip = spaceShipObject.GetComponent<Asteroids_SpaceShip>();
        spaceShip.initialize(sys.defaultMovementSpeed, sys.defaultRotationSpeed);

        StartCoroutine("CheckForInputPress");
        StartCoroutine("CheckForInputHold");
        StartCoroutine("CheckForGameOver");
        StartCoroutine("SpawnObstacle");
    }

    IEnumerator CheckForInputPress() {
        while (true) {
            if (Input.GetKeyDown(sys.inputPause)) toggleIsPaused();

            yield return null;
        }
    }

    IEnumerator CheckForInputHold() {
        while (true) {
            if (!isPaused) {
                if (Input.GetKey(sys.inputMoveForward)) spaceShip.moveForward();
                if (Input.GetKey(sys.inputMoveBackward)) spaceShip.moveBackward();
                if (Input.GetKey(sys.inputRotateRight)) spaceShip.rotateRight();
                if (Input.GetKey(sys.inputRotateLeft)) spaceShip.rotateLeft();
            }

            yield return null;
        }
    }

    IEnumerator CheckForGameOver() {
        while (true) {
            if (PlayerPrefs.GetInt("asteroids_gameOver") == 1) {
                ui.terminate();
                Destroy(this);
            }

            yield return new WaitForSeconds(sys.checkForGameOverCooldown);
        }
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            if (!isPaused) {
                nextObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                Instantiate(
                    nextObstacle, 
                    new Vector3(
                            sys.obstacleSpawnPositionX, 
                            0, 
                            sys.obstacleSpawnPositionZ),
                    Quaternion.identity, 
                    playfield);
                nextObstacle.GetComponent<Asteroids_Obstacle>().initialize();
            }

            yield return new WaitForSeconds(sys.obstacleSpawnCooldown);
        }
    }

    private void toggleIsPaused() => isPaused = !isPaused;
}
