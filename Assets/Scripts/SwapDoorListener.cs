using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapDoorListener : MonoBehaviour
{
    public bool caughtPlayer;
    // Start is called before the first frame update
    void Start()
    {
        caughtPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            caughtPlayer = true;
        }

    }

    void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            caughtPlayer = false;
        }

    }
}
