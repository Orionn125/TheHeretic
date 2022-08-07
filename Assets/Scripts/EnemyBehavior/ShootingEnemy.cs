
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public float agrooDistance;
    private bool agroo;

    public Transform shotPoint;
    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;

    void Update()
    {
        if (Time.time > nextShotTime && agroo)
        {
            Instantiate(projectile, shotPoint.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if (target != null)
        {
            agroo = (Vector2.Distance(transform.position, target.position) < agrooDistance);

            if (Vector2.Distance(transform.position, target.position) < minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }
        }
    }
}
