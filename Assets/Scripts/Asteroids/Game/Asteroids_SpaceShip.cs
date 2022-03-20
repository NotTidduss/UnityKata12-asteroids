using UnityEngine;

public class Asteroids_SpaceShip : MonoBehaviour
{
    //* private vars
    private float movementSpeed;
    private float rotationSpeed;


    public void Initialize(float movementSpeedSetting, float rotationSpeedSetting) {
        movementSpeed = movementSpeedSetting;
        rotationSpeed = rotationSpeedSetting;
    }


    public void accelerate() => move(movementSpeed);
    public void brake() => move(-movementSpeed);
    public void rotateLeft() => rotate(rotationSpeed);
    public void rotateRight() => rotate(-rotationSpeed);


    private void move(float movementSpeed) => GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, movementSpeed * 100));
    private void rotate(float rotationSpeed) => transform.Rotate(0, 0, rotationSpeed);


    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Obstacle") {
            PlayerPrefs.SetInt("asteroids_gameState", (int)Asteroids_GameState.GAME_OVER);
        }
    }
}
