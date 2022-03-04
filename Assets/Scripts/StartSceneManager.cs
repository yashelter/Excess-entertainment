using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class StartSceneManager : MonoBehaviour
{
    public string sent1;
    public string sent2;
    public string sent3;
    public string sent4;

    public TextMeshProUGUI text;
    public void Start()
    {
        text.text = "";
        StartCoroutine(Display());
    }
    public IEnumerator Display()
    {
        string line = "";
        for (int i = 0; i < sent1.Length; i++)
        {
            line += sent1[i];
            text.text = line;
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(2f);
        for (int i = sent1.Length; i > 0; i--)
        {
            line = line.Substring(0, i);
            text.text = line;
            yield return new WaitForSeconds(0.003f);
        }
        text.text = "";
        line = "";
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < sent2.Length; i++)
        {
            line += sent2[i];
            text.text = line;
            yield return new WaitForSeconds(0.08f);
        }
        //text.text = "";
        yield return new WaitForSeconds(2f);
        for (int i = sent2.Length; i > 0; i--)
        {
            line = line.Substring(0, i);
            text.text = line;
            yield return new WaitForSeconds(0.003f);
        }
        //text.text = "";
        line = "";
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < sent3.Length; i++)
        {
            line += sent3[i];
            text.text = line;
            yield return new WaitForSeconds(0.08f);
        }
        text.text = "";

        yield return new WaitForSeconds(1f);
        text.text = sent4 + "" +  PlayerPrefs.GetInt("try");
        PlayerPrefs.SetInt("try", PlayerPrefs.GetInt("try") + 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
