using System.Collections.Generic;
using UnityEngine;

public class Asteroids_SpaceShipMaster : MonoBehaviour
{
    [Header("Ship Collection")]
    [SerializeField] private List<Asteroids_SpaceShip> spaceShips;


    //* private vars
    private Asteroids_System sys;
    private Asteroids_SpaceShip selectedSpaceShip, currentSpaceShip;

    public void Initialize(Asteroids_System sysRef, GameObject spawn, Transform playAreaTransformRef) {
        // set private vars
        sys = sysRef;
        selectedSpaceShip = spaceShips[0];

        // spawn spaceShip
        currentSpaceShip = Instantiate(selectedSpaceShip, spawn.transform);
        currentSpaceShip.Initialize(sys.defaultMovementSpeed, sys.defaultRotationSpeed, playAreaTransformRef);
    }


    public void communicateControlToSpaceShip(Asteroids_SpaceShipControl control) {
        switch (control) {
            case Asteroids_SpaceShipControl.ACCELERATE: currentSpaceShip.accelerate(); break;
            case Asteroids_SpaceShipControl.BRAKE: currentSpaceShip.brake(); break;
            case Asteroids_SpaceShipControl.ROTATE_LEFT: currentSpaceShip.rotateLeft(); break;
            case Asteroids_SpaceShipControl.ROTATE_RIGHT: currentSpaceShip.rotateRight(); break;
            case Asteroids_SpaceShipControl.SHOOT: currentSpaceShip.shoot(); break;
        }
    }

    public Vector3 getSpaceShipPosition() => currentSpaceShip.transform.localPosition;
}
