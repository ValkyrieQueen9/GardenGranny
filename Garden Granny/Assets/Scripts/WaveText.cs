using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    private GameObject[] allwavetext;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;

    public GameObject winText;
    public GameObject failText;

    private GameObject spawnerObj;
    private WaveSpawner waveSpawner;

    private GameObject gameManagerObj;
    private GameManager gameManagerScript;

    void Start()
    {
        //Sets all wavetexts as inactive at beginning of game
        allwavetext = GameObject.FindGameObjectsWithTag("WaveText");
            foreach (GameObject t in allwavetext)
            {
                t.SetActive(false);
            }

        //Find and sets WinText and FailText as inactive at beginning of game
        winText.SetActive(false);
        failText.SetActive(false);

        //Finds the Spawner and WaveSpawner Script
        spawnerObj = GameObject.Find("Fly2Spawner1");
        waveSpawner = spawnerObj.GetComponent<WaveSpawner>();

        gameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();

    }

    void Update()
    {
        //If a wavePopUp bool is true in the wave Spawner script, the coroutine starts
        if (waveSpawner.wave1PopUp == true)
        {
            StartCoroutine(PopUp(text1));
            waveSpawner.wave1PopUp = false;
        }

        if (waveSpawner.wave2PopUp == true)
        {
            StartCoroutine(PopUp(text2));
            waveSpawner.wave2PopUp = false;
        }

        if (waveSpawner.wave3PopUp == true)
        {
            StartCoroutine(PopUp(text3));
            waveSpawner.wave3PopUp = false;
        }

        if (waveSpawner.wave4PopUp == true)
        {
            StartCoroutine(PopUp(text4));
            waveSpawner.wave4PopUp = false;
        }

        if (waveSpawner.wave5PopUp == true)
        {
            StartCoroutine(PopUp(text5));
            waveSpawner.wave5PopUp = false;
        }

        if (gameManagerScript.gameWin == true)
        {
            StartCoroutine(LongPopUp(winText));
        }

        if (gameManagerScript.gameFail == true)
        {
            StartCoroutine(LongPopUp(failText));
        }
    }

    IEnumerator PopUp (GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }

    IEnumerator LongPopUp (GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
    }
}
