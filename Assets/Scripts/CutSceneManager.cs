using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    public GameObject controlCenter;

    public void OnEnable()
    {
        controlCenter.SetActive(false);
    }
    public void OnDisable()
    {
        controlCenter.SetActive(true);
    }

}
