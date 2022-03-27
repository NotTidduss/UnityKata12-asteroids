using System.Collections;
using UnityEngine;

public class Asteroids_InputMaster : MonoBehaviour
{
    //* private vars
    private Asteroids_System sys;
    private Asteroids_Master master;
    private int convertedRunningState;


    public void Initialize(Asteroids_System sysRef, Asteroids_Master masterRef) 
    {
        // set private vars
        sys = sysRef;
        master = masterRef;
        convertedRunningState = (int)Asteroids_GameState.GAME_RUNNING;

        // start Coroutines
        StartCoroutine(CheckForInputPress());
        StartCoroutine(CheckForInputHold());
    }


    IEnumerator CheckForInputPress() {
        while (true) {
            if (Input.GetKeyDown(sys.inputShoot)) master.communicateControlToSpaceShip(Asteroids_SpaceShipControl.SHOOT);
            if (Input.GetKeyDown(sys.inputPause))
                togglePause();

            yield return null;
        }
    }

    IEnumerator CheckForInputHold() {
        while (true) {
            if (PlayerPrefs.GetInt("asteroids_gameState") == convertedRunningState) {
                if (Input.GetKey(sys.inputAccelerate)) master.communicateControlToSpaceShip(Asteroids_SpaceShipControl.ACCELERATE);
                if (Input.GetKey(sys.inputBrake)) master.communicateControlToSpaceShip(Asteroids_SpaceShipControl.BRAKE);
                if (Input.GetKey(sys.inputRotateLeft)) master.communicateControlToSpaceShip(Asteroids_SpaceShipControl.ROTATE_LEFT);
                if (Input.GetKey(sys.inputRotateRight)) master.communicateControlToSpaceShip(Asteroids_SpaceShipControl.ROTATE_RIGHT);
            }

            yield return null;
        }
    }


    private void togglePause() {
        if ((Asteroids_GameState)PlayerPrefs.GetInt("asteroids_gameState") == Asteroids_GameState.GAME_RUNNING) {
            PlayerPrefs.SetInt("asteroids_gameState", (int)Asteroids_GameState.GAME_PAUSED);
        } else {
            PlayerPrefs.SetInt("asteroids_gameState", (int)Asteroids_GameState.GAME_RUNNING);
        }
    }
}
