using System.Collections;
using UnityEngine;

public class Asteroids_Master : MonoBehaviour
{
    [Header ("Scene References")]
    public Asteroids_System sys;
    [SerializeField] private Asteroids_InputMaster inputMaster;
    [SerializeField] private Asteroids_UI ui;
    [SerializeField] private Transform playfield;


    //* private vars
    private GameObject spaceShipObject;
    private GameObject nextObstacle;
    private Asteroids_SpaceShip spaceShip;
    private bool isPaused;


    void Start() {
        // prepare private variables
        isPaused = false;

        // prepare game
        sys.resetPlayerPrefs();
        inputMaster.initialize(sys, this);        
        ui.initialize(sys, this);

        StartCoroutine("CheckForGameOver");
        StartCoroutine("SpawnObstacle");
    }


    IEnumerator CheckForGameOver() {
        while (true) {
            if (PlayerPrefs.GetInt("asteroids_gameState") == 2) {
                ui.terminate();
                Destroy(this);
            }

            yield return new WaitForSeconds(sys.checkForGameOverCooldown);
        }
    }

    IEnumerator SpawnObstacle() {
        while (true) {
            if (!isPaused) {
                /*
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
                */
            }

            yield return new WaitForSeconds(sys.obstacleSpawnCooldown);
        }
    }


    public void communicateControlToSpaceShip(Asteroids_SpaceShipControl control) => ui.communicateControlToSpaceShip(control);


    private void toggleIsPaused() => isPaused = !isPaused;
}
