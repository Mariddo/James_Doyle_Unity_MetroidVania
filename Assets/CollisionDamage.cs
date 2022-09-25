using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    
    public int damageAmount = 10;

    void OnCollisionStay2D(Collision2D other) {

        if(other.gameObject.tag == "Player") {

            other.gameObject.GetComponent<Player>().TakeDamage(damageAmount);
        }

    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {

             other.gameObject.GetComponent<Player>().TakeDamage(damageAmount);
        }


    }

}
