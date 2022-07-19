using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{

    public GameObject mainMenu;
    public MainMenu mainMenuScript;

    public GameObject readyText;

    private int runOnce = 0;

    private void Start()
    {
        readyText.SetActive(false);

        mainMenu = GameObject.Find("MainMenu");
    }

    private void Update()
    {

        if (MainMenu.fromStartGame == true & runOnce == 0)
        {
            Debug.Log("FromStartGame is true");
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
