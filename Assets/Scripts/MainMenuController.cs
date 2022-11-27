using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string newGameScene;

    public GameObject continueButton;

    public Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("ContinueLevel")) {
            continueButton.SetActive(true);

        }
        else {
            continueButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {

        PlayerPrefs.DeleteKey("ContinueLevel");
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");

        SceneManager.LoadScene(newGameScene);

        AudioManager.instance.mainMenuMusic.Stop();
    }

    public void Continue() {

        AudioManager.instance.mainMenuMusic.Stop();

        player.gameObject.SetActive(true);
        player.transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"),
        PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));

        player.gameObject.SetActive(true);
        SceneManager.LoadScene(PlayerPrefs.GetString("ContinueLevel"));
    }

    public void Quit() {

        Application.Quit();

        Debug.Log("Game Quit");
    }
}
