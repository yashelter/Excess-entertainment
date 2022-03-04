using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class End : MonoBehaviour
{
    public GameObject panelka;

    void Start()
    {
        panelka.SetActive(true);
        StartCoroutine(Ending());
    }
    public IEnumerator Ending()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(0);
    }

}
