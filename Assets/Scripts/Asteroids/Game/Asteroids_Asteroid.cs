using System.Collections;
using UnityEngine;

public class Asteroids_Asteroid : MonoBehaviour
{
    //* private vars
    private Vector3 movingDirection;


    public void Initialize(Vector3 playerPosition)
    {
        Vector3 currentPosition = transform.position;
        this.transform.localPosition = currentPosition;

        movingDirection = playerPosition - currentPosition;
        movingDirection = movingDirection * 0.0025f;

        StartCoroutine(Move());
    }


    IEnumerator Move()
    {
        for(;;)
        {
            transform.Translate(movingDirection);
            if (isOutOfBounds()) Destroy(this.gameObject);

            yield return null;
        }
    }


    private bool isOutOfBounds()
    {
        return transform.localPosition.x < -1000 
                || transform.localPosition.x > 1000 
                || transform.localPosition.y > 550 
                || transform.localPosition.y < -550;
    }
}
