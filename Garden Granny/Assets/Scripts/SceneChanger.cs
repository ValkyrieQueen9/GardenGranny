using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private GameObject scoreGameObj;
    public static bool endOfGame2;
    private int runOnce = 0;

    public GameObject sceneTransitions;
    public Transitions transitionsScript;
    public int sceneIndex;

    private GameObject transitionGameObj;
    public Animator transitionAnim;
    public string transitionTrigger;

    public static bool fromEndGame = false;
    public static bool fromStartGame = false;

    public static bool winEnd;
    public static bool failEnd;

    public GameObject gameManager;
    public GameManager gameManagerScript;

    public float tranTime = 1f;

    public static SceneChanger instance;


    void Start()
    {

        scoreGameObj = GameObject.FindGameObjectWithTag("Score");

        //sceneTransitions = GameObject.Find("SceneTransitions");
        //transitionsScript = sceneTransitions.GetComponent<Transitions>();
       

        transitionGameObj = GameObject.Find("Transition");
        transitionAnim = transitionGameObj.GetComponent<Animator>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

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
        sceneTransitions = GameObject.Find("SceneTransitions");
        transitionsScript = sceneTransitions.GetComponent<Transitions>();

        //Maybe for different end menu text
        winEnd = gameManagerScript.gameWin;
        failEnd = gameManagerScript.gameFail;

        if (gameManagerScript.endOfGame == true & runOnce == 0)
        {
            runOnce++;
            fromEndGame = true;
            Debug.Log("End of Game is called! ");
            StartCoroutine(WaitForLongPopUp(tranTime));
        }

    }

        //Give time for Win and Fail Text to popup
        IEnumerator WaitForLongPopUp(float tranTime)
        {
            yield return new WaitForSeconds(2f);
            transitionsScript.LoadNextScene(tranTime);
        }

}
