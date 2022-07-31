using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScenes : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject mainMenu;

    private int runOnce = 0;

    void Update()
    {
        //If the game is over via win or lose, show game over text and score.
        if (SceneChanger.fromEndGame == true & runOnce == 0)
        {
            endMenu.SetActive(true);
            mainMenu.SetActive(false);
            runOnce++;
        }
    }
}
