using UnityEngine.SceneManagement;
using UnityEngine;
public class InGameManager : MonoBehaviour
{
    public bool gameActive = true;
    public GameObject PausePannel;
    public GameObject ActivePanel;
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ClickPauseGame();
        }
    }
    public void Start()
    {
        PausePannel.SetActive(false);
        ActivePanel.SetActive(true);
    }
    public void ClickPauseGame()
    {
        Time.timeScale = 0;
        gameActive = false;
        ActivePanel.SetActive(false);
        PausePannel.SetActive(true);
    }
    public void ClickContinueGame()
    {
        Time.timeScale = 1;
        gameActive = true;
        ActivePanel.SetActive(true);
        PausePannel.SetActive(false);
    }
    public void ClickToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
