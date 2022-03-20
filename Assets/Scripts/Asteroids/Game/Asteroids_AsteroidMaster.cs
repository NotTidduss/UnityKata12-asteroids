using System.Collections;
using UnityEngine;

public class Asteroids_AsteroidMaster : MonoBehaviour
{
    [Header("Asteroid Prefab")]
    [SerializeField] private GameObject asteroidPrefab;


    [Header("Scene References")]
    [SerializeField] private Transform playArea;


    //* links
    private Asteroids_UI ui;



    public void Initialize(Asteroids_UI uiRef) 
    {
        ui = uiRef;

        StartCoroutine(SpawnAsteroid());    
    }


    IEnumerator SpawnAsteroid()
    {
        for (;;)
        {
            GameObject asteroidObject = Instantiate(asteroidPrefab, getRandomizedPosition(), Quaternion.identity, playArea);
            asteroidObject.GetComponent<Asteroids_Asteroid>().Initialize(ui.getSpaceShipPosition());

            yield return new WaitForSeconds(2);
        }
    }


    private Vector3 getRandomizedPosition()
    {
        int randomizedSide = Random.Range(0, 4);
        switch(randomizedSide)
        {
            case 0: return new Vector3(-900, Random.Range(-500f, 500f), 0);
            case 1: return new Vector3(Random.Range(-900f, 900f), 500, 0);
            case 2: return new Vector3(900, Random.Range(-500f, 500f), 0);
            case 3: return new Vector3(Random.Range(-900f, 900f), -500, 0);
            default: return Vector3.zero;
        }
    }
}
