using System.Collections;
using UnityEngine;

public class Asteroids_Master : MonoBehaviour
{
    [Header ("Scene References")]
    public Asteroids_System sys;
    [SerializeField] private Asteroids_InputMaster inputMaster;
    [SerializeField] private Asteroids_UI ui;


    //* private vars
    private GameObject spaceShipObject;
    private GameObject nextObstacle;
    private Asteroids_SpaceShip spaceShip;
    private bool isPaused;


    void Awake() 
    {
        Application.targetFrameRate = 60;
        Asteroids_PlayerPrefsMaster.resetAsteroidsPlayerPrefs();
    }


    void Start() 
    {
        // prepare private variables
        isPaused = false;

        // prepare game
        inputMaster.Initialize(sys, this);        
        ui.Initialize(sys, this);

        StartCoroutine("CheckForGameOver");
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


    public void communicateControlToSpaceShip(Asteroids_SpaceShipControl control) => ui.communicateControlToSpaceShip(control);


    private void toggleIsPaused() => isPaused = !isPaused;
}
