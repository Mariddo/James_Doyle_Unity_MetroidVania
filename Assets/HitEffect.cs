using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    
    public bool destroyMe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyMe) {
            Destroy(gameObject);
        }
    }

    public void Destroy() {

        Destroy(gameObject);
    }
}
