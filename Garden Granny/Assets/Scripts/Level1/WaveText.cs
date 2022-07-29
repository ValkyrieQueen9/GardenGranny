using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public GameManager gameManagerScript;

    public GameObject winText;
    public GameObject failText;

    public GameObject[] allwavetext;

    void Start()
    {
        //Sets all wavetexts as inactive at beginning of game
        foreach (GameObject t in allwavetext)
            {
                t.SetActive(false);
            }

        //Find and sets WinText and FailText as inactive at beginning of game
        winText.SetActive(false);
        failText.SetActive(false);
    }

    void Update()
    {
        //If a wavePopUp bool is true in the WaveSpawner script, the coroutine starts
        if (waveSpawner.wave1PopUp == true)
        {
            StartCoroutine(PopUp(allwavetext[0]));
            waveSpawner.wave1PopUp = false;
        }

        if (waveSpawner.wave2PopUp == true)
        {
            StartCoroutine(PopUp(allwavetext[1]));
            waveSpawner.wave2PopUp = false;
        }

        if (waveSpawner.wave3PopUp == true)
        {
            StartCoroutine(PopUp(allwavetext[2]));
            waveSpawner.wave3PopUp = false;
        }

        if (waveSpawner.wave4PopUp == true)
        {
            StartCoroutine(PopUp(allwavetext[3]));
            waveSpawner.wave4PopUp = false;
        }

        if (waveSpawner.wave5PopUp == true)
        {
            StartCoroutine(PopUp(allwavetext[4]));
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

    //Enables text briefly then disables
    IEnumerator PopUp (GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }

    //Enables text for longer then disables
    IEnumerator LongPopUp (GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
    }
}
