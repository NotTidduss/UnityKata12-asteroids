using System.Collections;
using UnityEngine;

public class Asteroids_Projectile : MonoBehaviour
{
    public void Initialize() => StartCoroutine(CheckForOOB());


    IEnumerator CheckForOOB()
    {
        for(;;)
        {
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
