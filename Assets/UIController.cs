using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text text;
    
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {

            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        if (player != null) {

            text.text = player.currentHitPoints.ToString();
        }
    }
}
