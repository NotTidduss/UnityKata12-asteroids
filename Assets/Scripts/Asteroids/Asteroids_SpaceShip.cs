using UnityEngine;

public class Asteroids_SpaceShip : MonoBehaviour
{
    private float movementSpeed;
    private float rotationSpeed;

    public void initialize(float movementSpeedSetting, float rotationSpeedSetting) {
        movementSpeed = movementSpeedSetting;
        rotationSpeed = rotationSpeedSetting;
    }

    public void moveForward() => move(movementSpeed);
    public void moveBackward() => move(-movementSpeed);
    public void rotateRight() => rotate(rotationSpeed);
    public void rotateLeft() => rotate(-rotationSpeed);
    private void move(float movementSpeed) => transform.Translate(0,0,movementSpeed);
    private void rotate(float rotationSpeed) => transform.Rotate(0,rotationSpeed,0);

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Obstacle") {
            PlayerPrefs.SetInt("asteroids_gameOver", 1);
        }
    }
}
