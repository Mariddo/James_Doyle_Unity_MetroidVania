using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int totalHealth;

    public GameObject deathEffect;
    
    public void DamageEnemy(int damage) {
        totalHealth -= damage;

        if (totalHealth <= 0) {

            DestroyEnemy();
        }

    }

    void DestroyEnemy() {

        if(deathEffect != null) {

            Instantiate(deathEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
