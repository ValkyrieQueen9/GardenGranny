using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    public GameObject readyText;

    private int runOnce = 0;

    private void Start()
    {
        readyText.SetActive(false);
    }

    private void Update()
    {
        //If the game is starting through main menu, trigger "Get Ready" text
        if (MainMenu.fromStartGame == true & runOnce == 0)
        {
            StartCoroutine(PopUp(readyText));
            runOnce++;
        }
    }
    IEnumerator PopUp(GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}
