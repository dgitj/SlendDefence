using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject MainCanvas;

    public void QuitGame()
    {
        SceneManager.LoadScene("MENU");
    }

    public void LoadMenu()
    {
        MainCanvas.SetActive(true);
    }
}
