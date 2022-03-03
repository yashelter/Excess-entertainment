using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public Transform targerTransform;

    public Transform layer1;
    public Transform layer2;

    public float lastPositon;
    public void Update()
    {
        if(lastPositon < targerTransform.position.x)
        {
            layer1.Translate(new Vector3(-0.002f, 0, 0));
            layer2.Translate(new Vector3(-0.001f, 0, 0));
            lastPositon = targerTransform.position.x;
        }
        else if(lastPositon > targerTransform.position.x)
        {
            layer1.Translate(new Vector3(0.002f, 0, 0));
            layer2.Translate(new Vector3(0.001f, 0, 0));
            lastPositon = targerTransform.position.x;
        }
    }
}
