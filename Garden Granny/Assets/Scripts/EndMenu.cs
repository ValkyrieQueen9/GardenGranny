using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI scoreNum;
    public string playerScore;
    public Score scoreScript;

    private GameObject scenesObj;
    private SceneChanger sceneChanger;
    private int runOnce = 0;

    public GameObject scoreCanvas;
    private Canvas scoreCanvasComp;


    private void Update()
    {
        scenesObj = GameObject.Find("Scenes");
        sceneChanger = scenesObj.GetComponent<SceneChanger>();

        if (SceneChanger.fromEndGame == true & runOnce == 0)
        {
            scoreScript = FindObjectOfType<Score>();

            runOnce++;
            playerScore = scoreScript.playerScore.ToString();
            scoreNum.text = playerScore;

            //SceneChanger.fromEndGame = false;
        }


    }

}
