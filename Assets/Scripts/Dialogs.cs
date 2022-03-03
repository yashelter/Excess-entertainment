using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogs : MonoBehaviour
{
    [System.Serializable]
    public struct Replic
    {
        public string name;
        public string sentense;
    }
    public Replic[] replicList;

    [System.Serializable]
    public struct Sayer
    {
        public string name;
        public Sprite image;
    }
    public Sayer[] sayers;
    public Image image;
    public TextMeshProUGUI text;
    public GameObject UI;
    public GameObject thisDialog;
    public void Start()
    {
        StartCoroutine(startALL());
    }
    public IEnumerator startALL()
    {
        UI.SetActive(false);
        text.text = "";
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < replicList.Length; i++)
        {
            string curName = replicList[i].name, curSent = replicList[i].sentense, write = "";
            Sprite curImage = null;
            for (int j = 0; j < sayers.Length; j++)
            {
                if (sayers[j].name == curName)
                {
                    curImage = sayers[j].image;
                    break;
                }
            }
            image.sprite = curImage;
            if (i == replicList.Length - 1)
            {
                yield return new WaitForSeconds(2f);
            }
            for (int j = 0; j < curSent.Length; j++)
            {
                write += curSent[j];
                text.text = write;
                yield return new WaitForSeconds(0.033f);
            }
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(4f);
        UI.SetActive(true);
        Destroy(thisDialog);
    }
    
}
