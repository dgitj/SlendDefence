using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{ 

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject UI;
    public GameObject FPSController;
    public GameObject Hand;
    public GameObject MainCanvas;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }
     
    public void Resume()
    {
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        UI.SetActive(true);
        Hand.SetActive(true);
    }

    public void Pause()
    {
        
        Time.timeScale = 0f;
        GameIsPaused = true;
        PauseMenuUI.SetActive(true);   
        UI.SetActive(false);
        Hand.SetActive(false);
       
    }

    public void LoadMenu()
    {
        PauseMenuUI.SetActive(false);
        UI.SetActive(false);
        Hand.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
        MainCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
