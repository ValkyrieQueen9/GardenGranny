using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject[] crops;

    public bool gameWin = false; //WaveSpawner can change it - WaveText uses it ---- Add new gameWin true when check if finished

    public bool gameFail = false; //Changed here, used by fly2move, scene changer and waveText

    public bool endOfGame = false; //game end either way - use in gameFail and gameWin

    private GameObject waveSpawnerObj;
    private WaveSpawner waveSpawnerScript;

    private Score scoreScript;
    private SceneChanger sceneChanger;

    private int runOnce = 0;


    void Start()
    {
        scoreScript = FindObjectOfType<Score>();

        waveSpawnerObj = GameObject.FindGameObjectWithTag("Spawner");
        waveSpawnerScript = waveSpawnerObj.GetComponent<WaveSpawner>();

        crops = GameObject.FindGameObjectsWithTag("Crop");
    }

    void Update()
    {
       
        //GameWin Check
        if (gameWin == true)
            {
                endOfGame = true;
            }


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
            Debug.Log("Game Manager Game over");
            runOnce ++;
            endOfGame = true;
        }

        //EndofGame control here? currently in wavespawner and used by score
    
    }

}
