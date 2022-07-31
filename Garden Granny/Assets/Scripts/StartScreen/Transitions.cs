using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public Animator transition;

    //Triggers scene change
    public void LoadNextScene(float tranTime)
    {
        StartCoroutine(LoadLevel(tranTime));
    }

    //Changes scene with smooth fade transition
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
