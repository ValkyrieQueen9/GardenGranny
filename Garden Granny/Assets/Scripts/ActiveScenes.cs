using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveScenes : MonoBehaviour
{
    private GameObject scenesObj;
    private SceneChanger sceneChanger;

    public GameObject endMenu;
    public GameObject mainMenu;
    public GameObject scoreCanvas;
    private Canvas scoreCanvasComp;

    private int runOnce = 0;

    void Update()
    {
        scenesObj = GameObject.Find("Scenes");
        //sceneChanger = scenesObj.GetComponent<SceneChanger>();

        if (SceneChanger.fromEndGame == true & runOnce == 0)
        {
            Debug.Log("fromEndGame is true");

            /*
            scoreCanvas = GameObject.Find("ScoreCanvas");
            scoreCanvasComp = scoreCanvas.GetComponent<Canvas>();
            scoreCanvasComp.enabled = false;
            */

            endMenu.SetActive(true);
            mainMenu.SetActive(false);
            runOnce++;
        }
    }
}
