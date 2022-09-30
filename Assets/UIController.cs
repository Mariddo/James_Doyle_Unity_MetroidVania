using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    public GameObject pauseScreen;

    private void Awake() {

        if(instance == null) {

            instance = this;
            DontDestroyOnLoad(gameObject);
        } else{
            Destroy(gameObject);
        }
        

    }

    public TMP_Text text;

    public string mainMenu = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Player.instance.currentHitPoints.ToString();

        if(Input.GetKeyDown(KeyCode.Escape)) {

            PauseUnpause();
        }
    }

    void PauseUnpause() {

        if (!pauseScreen.activeSelf) {

            pauseScreen.SetActive(true);

            Time.timeScale = 0f;
        } else {

            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    void MainMenu() {

        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;

        Destroy(Player.instance.gameObject);
        Player.instance = null;

        Destroy(RespawnController.instance.gameObject);
        RespawnController.instance = null;
    }

    public void Resume() {

        if (pauseScreen.activeSelf) {

            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }
}
