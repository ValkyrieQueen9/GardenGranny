using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Transitions transitionsScript;
    public bool fromStartGame = false;

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

    //Resume Game from pause menu and begin gameplay
   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Activate pause menu overlay and stop gameplay
   void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Load start screen
    public void LoadMenu()
    {
        GameIsPaused = false;
        transitionsScript.LoadNextScene(1f);
        Time.timeScale = 1f;
    }

    

}
