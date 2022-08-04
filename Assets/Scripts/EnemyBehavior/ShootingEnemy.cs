using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;

    public Transform shotPoint;
    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;

    void Update()
    {
        if (Time.time > nextShotTime)
        {
            Instantiate(projectile, shotPoint.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}
