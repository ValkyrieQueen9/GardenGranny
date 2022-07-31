using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public WaveSpawner waveSpawnerScript;
    public Score scoreScript;

    [Header("Game Results")]
    public bool gameWin = false;
    public bool gameFail = false;
    public bool endOfGame = false;

    private GameObject[] crops;
    private int runOnce = 0;

    void Start()
    {
        crops = GameObject.FindGameObjectsWithTag("Crop");
    }

    void Update()
    {
        //Sets gameFail as true when all crops are inactive or "killed"
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            bool allDisabled = true;

            for (int i = 0; i < crops.Length; i++)
            {
                if (crops[i].activeSelf)
                    { 
                        allDisabled = false; break; 
                    }
            }

            if (allDisabled) 
            { 
                gameFail = true;
            }
        }

        //GameFail Check
        if (gameFail == true & runOnce == 0)
        {
            Debug.Log("Game Over - FAIL");
            runOnce ++;
            endOfGame = true;
        }

        //Sets gameWin when all waves are complete
        if(waveSpawnerScript.allWavesComplete)
        {
            gameWin = true;
        }

        //GameWin Check
        if (gameWin == true & runOnce == 0)
        {
            Debug.Log("Game Over - WIN");
            runOnce++;
            endOfGame = true;
        }

    }

}
