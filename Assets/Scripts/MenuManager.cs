using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void OnQuit()
    {
       Application.Quit();
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }
}
