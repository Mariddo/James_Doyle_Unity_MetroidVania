using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public static RespawnController instance;
    
    public Vector3 spawnPoint;

    private void Awake() {

        if(instance == null) {

            instance = this;
            DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }
        

    }
    
    private Vector3 respawnPoint;
    public float waitToSpawn = 1f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn() {

        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo() {

        Player.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToSpawn);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Player.instance.FullyRestoreHealth();
        Player.instance.gameObject.SetActive(true);

        Player.instance.transform.position = spawnPoint;
    }

    public void SetSpawn(Vector3 pos) {

        respawnPoint = pos;

    }
}
