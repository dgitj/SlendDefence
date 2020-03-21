using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject UI;
    public GameObject Hand;
    public GameObject PauseCanvas;

    public void Start()
    {
        UI.SetActive(false);
        Hand.SetActive(false);
        PauseCanvas.SetActive(false);
        PauseMenu.GameIsPaused = true;
            
        
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene("MAIN");
        Time.timeScale = 1f;
        UI.SetActive(true);
        Hand.SetActive(true);
        PauseCanvas.SetActive(false);
        PauseMenu.GameIsPaused = false;

    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
}
