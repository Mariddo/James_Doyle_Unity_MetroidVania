using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string newGameScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {

        SceneManager.LoadScene(newGameScene);
    }

    public void Continue() {


    }

    public void Quit() {

        Application.Quit();

        Debug.Log("Game Quit");
    }
}
