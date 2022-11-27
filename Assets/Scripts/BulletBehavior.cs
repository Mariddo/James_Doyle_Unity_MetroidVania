using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Vector2 moveDir;

    public float bulletSpeed = 20f;

    private Rigidbody2D rb;
    
    public GameObject hitEffect;

    public int damageAmount;

    // Start is called before the first frame update

    void Start() {

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = moveDir * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D col) {

        if(col.tag == "Enemy") {

            Debug.Log("Hitting an Enemy");
            col.GetComponent<Enemy>().DamageEnemy(damageAmount);
        }
        
        Instantiate(hitEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        
    }

    private void OnBecameInvisible() {

        Destroy(gameObject);
    }
}
