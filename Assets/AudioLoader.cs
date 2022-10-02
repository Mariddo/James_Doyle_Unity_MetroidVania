using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoader : MonoBehaviour
{
    public AudioManager am;

    private void Awake() {

        AudioManager newAM = Instantiate(am);
        AudioManager.instance = newAM;
        DontDestroyOnLoad(newAM.gameObject);
    }
}
