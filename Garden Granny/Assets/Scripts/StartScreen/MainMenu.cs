using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static bool fromStartGame = false;

    public void PlayGame()
    {
       //Begins game - used with StartButton
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
       fromStartGame = true;
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        //Triggers next scene with a smooth fade transition
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
