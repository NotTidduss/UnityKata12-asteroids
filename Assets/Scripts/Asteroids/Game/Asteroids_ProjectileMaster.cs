using UnityEngine;

public class Asteroids_ProjectileMaster : MonoBehaviour
{
    [Header ("Projectile Prefab")]
    [SerializeField] private GameObject projectilePrefab;


    //* private vars
    private Transform playAreaTransform;


    public void Initialize(Transform playAreaTransformRef) => playAreaTransform = playAreaTransformRef;


    public void shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, this.gameObject.transform.position, this.gameObject.transform.parent.rotation, playAreaTransform);
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 5000));
        projectile.GetComponent<Asteroids_Projectile>().Initialize();
    }
}
