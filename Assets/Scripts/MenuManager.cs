using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void OnQuit()
    {
       Application.Quit();
    }
    public void OnPlay()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(1)); 
    }

    //IEnumerator LoadLevel(int levelIndex)
    //{
    //    transition.SetTrigger("Start");

    //    yield return new WaitForSeconds(transitionTime);

    //    SceneManager.LoadScene(levelIndex);
    //}
    IEnumerator LoadLevel(int levelIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                transition.SetTrigger("Start");
                yield return new WaitForSeconds(1f);
                asyncLoad.allowSceneActivation = true;
                
            }
            yield return null;
        }
    }
}
