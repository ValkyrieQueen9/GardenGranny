using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public int enemiesKilled;
    public int cropsKilled;

    public bool endOfGame;

    private int enemiesPoints;
    private int cropsPoints;

    private GameObject gameManagerObj;
    private GameManager gameManagerScript;

    //public string nextScene;
    //public GameObject gameObjectToSend;

    private void Start()
    {
        endOfGame = false;

        enemiesKilled = 0;
        cropsKilled = 0;

        gameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();
    }


    void Update()
    {
        if (gameManagerScript.endOfGame == true)
        {
            enemiesPoints = enemiesKilled * 100;
            cropsPoints = cropsKilled * 50;

            playerScore = enemiesPoints;
            playerScore -= cropsPoints;

            //scoreText.text = playerScore.ToString();

       }
    }


}
