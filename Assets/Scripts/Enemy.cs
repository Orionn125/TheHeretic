using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Animator camAnim;
    public int health;
    public GameObject deathEffect;
    public GameObject explosion;
    private GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();    
    }

    private void Update()
    {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            gc.killCount++;
        }
    }

    public void TakeDamage(int damage) {
        camAnim.SetTrigger("shake");
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
