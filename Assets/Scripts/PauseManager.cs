using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject first;
    public GameObject second;

    public void First()
    {
        Time.timeScale = 0;
        first.SetActive(true);
        second.SetActive(false);
    }
    public void Second()
    {
        Time.timeScale = 1;
        second.SetActive(true);
        first.SetActive(false);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
