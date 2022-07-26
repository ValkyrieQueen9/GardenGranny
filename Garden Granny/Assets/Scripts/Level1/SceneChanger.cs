using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float tranTime = 1f;
    
    [Header("Scripts")]
    public Transitions transitionsScript;
    public Animator transitionAnim;
    public GameManager gameManagerScript;

    public static bool fromEndGame = false;

    public static SceneChanger instance;

    private int runOnce = 0;

    void Start()
    {
        //Avoids duplicate scripts in a scene
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Destroyed " + this.name);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }


    void Update()
    {
        //Changes scene when game ends
        if (gameManagerScript.endOfGame == true & runOnce == 0)
        {
            runOnce++;
            fromEndGame = true;
            Debug.Log("Changing Scene...");
            StartCoroutine(WaitForLongPopUp(tranTime));
        }

    }

        //Gives time for Win and Fail Text to popup
        IEnumerator WaitForLongPopUp(float tranTime)
        {
            yield return new WaitForSeconds(2f);
            transitionsScript.LoadNextScene(tranTime);
        }

}
