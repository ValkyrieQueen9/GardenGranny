using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [Header("Player Score")]
    public TextMeshProUGUI scoreNum;
    public string playerScore;

    private Score scoreScript;
    private int runOnce = 0;

    private void Start()
    {
        scoreScript = FindObjectOfType<Score>();
    }

    private void Update()
    {
        //If the game is over via win or lose, show player score
        if (SceneChanger.fromEndGame == true & runOnce == 0)
        {
            playerScore = scoreScript.playerScore.ToString();
            scoreNum.text = playerScore;
            runOnce++;
        }


    }

}
