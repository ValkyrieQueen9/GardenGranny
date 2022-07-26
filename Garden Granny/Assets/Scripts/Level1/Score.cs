using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameManager gameManagerScript;

    [Header("Player Score")]
    public int enemiesKilled;
    public int cropsKilled;
    public int playerScore;
    
    private int enemiesPoints;
    private int cropsPoints;

    private void Start()
    {
        enemiesKilled = 0;
        cropsKilled = 0;
    }

    void Update()
    {
        if (gameManagerScript.endOfGame == true)
        {
            enemiesPoints = enemiesKilled * 50;
            cropsPoints = cropsKilled *20;

            playerScore = enemiesPoints - cropsPoints;

       }
    }


}
