using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHitPoints = 99;

    public int currentHitPoints;

    public int attackDamage = 1;

    public float invincibilityLength;
    private float invincibilityCounter;

    public float flashLength;
    private float flashCounter;

    public SpriteRenderer sr;

    void Start() {

        currentHitPoints = maxHitPoints;
    }

    void Update() {

        if (invincibilityCounter > 0) {
            invincibilityCounter -= Time.deltaTime;
        }
        InvincibilityFlash();
    }

    public void TakeDamage(int damageAmount) {
        
        if(invincibilityCounter > 0) {
            return;
        }
        
        currentHitPoints -= damageAmount;

        HandleDeathCase();
    }

    void HandleDeathCase() {



        if(currentHitPoints <= 0) {
            currentHitPoints = 0;
            gameObject.SetActive(false);
        } else {

            invincibilityCounter = invincibilityLength;
        }
    }

    void InvincibilityFlash() {

        if (invincibilityCounter > 0) {
            if(flashCounter <= 0) {
                sr.enabled = !sr.enabled;
                flashCounter = flashLength;
            }
            else {
                flashCounter -= Time.deltaTime;
            }
            
        } else {
            sr.enabled = true;
        }
      
    }   
}
