using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public OpenDoorListener openListener;
    public SwapDoorListener swapListener;

    public Animator animator;

    public bool enterNextArea;

    public string nextAreaToEnter;

    public float timeToEnterNextArea = 0.75f;

    public Vector3 exitPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Open", openListener.caughtPlayer);

        enterNextArea = swapListener.caughtPlayer;

        DoorUsed();
    }

    void DoorUsed() {

        if(enterNextArea == true) {

            StartCoroutine(EnterNextArea());
        }
        
    }

    IEnumerator EnterNextArea() {

        yield return new WaitForSeconds(timeToEnterNextArea);

        DoorSavesInfo();

        SceneManager.LoadScene(nextAreaToEnter);

        RespawnController.instance.SetSpawn(exitPoint);

        Player.instance.transform.position = exitPoint;
    }

    void DoorSavesInfo() {

        PlayerPrefs.SetString("ContinueLevel", nextAreaToEnter);
        PlayerPrefs.SetFloat("PosX", exitPoint.x);
        PlayerPrefs.SetFloat("PosY", exitPoint.y);
        PlayerPrefs.SetFloat("PosZ", exitPoint.z);
    }

}
