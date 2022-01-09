using System;
using UnityEngine;
using UnityEngine.UI;

public class Asteroids_UI : MonoBehaviour
{
    [Header ("Scene References")]
    [SerializeField] private Asteroids_SpaceShipMaster spaceShipMaster;
    [SerializeField] private Asteroids_AsteroidMaster asteroidMaster;

    [Header ("UI Elements")]
    [SerializeField] private GameObject spaceShipSpawnPoint;


    [Header ("Menu")]
    [SerializeField] private GameObject resultMenu;


    [Header ("Text")]
    [SerializeField] private Text textNewHighScoreInfo;
    [SerializeField] private Text textScoreValue;
    [SerializeField] private Text textHighScoreValue;


    //* private vars
    private Asteroids_System sys;
    private Asteroids_Master master; 


    public void initialize(Asteroids_System sysRef, Asteroids_Master masterRef) {
        // set private vars
        sys = sysRef;
        master = masterRef;

        // initialize scene references
        spaceShipMaster.initialize(sysRef, spaceShipSpawnPoint);
        asteroidMaster.initialize();

        // initialize UI elements
        resultMenu.SetActive(false); 
    }

    public void terminate() => resultMenu.SetActive(true);


    public void communicateControlToSpaceShip(Asteroids_SpaceShipControl control) => spaceShipMaster.communicateControlToSpaceShip(control);


#region Button Events
    public void buttonPlayAgain() => master.sys.loadGameScene();
#endregion
}
