using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    public bool unlockDash;

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.tag == "Player") {

            PlayerAbilityTracker player = collision.GetComponentInParent<PlayerAbilityTracker>();

            if(unlockDash) {

                player.canDash = true;
            }

            Destroy(gameObject);
        }
    }
}
