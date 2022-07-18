using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public int sceneIndex;
    public Animator transition;
    public float transitionTime = 1f;


    public void LoadNextScene(float tranTime)
    {
        StartCoroutine(LoadLevel(tranTime));
    }

    IEnumerator LoadLevel(float tranTime)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(tranTime);
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
