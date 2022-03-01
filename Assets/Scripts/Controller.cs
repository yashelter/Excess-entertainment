using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform position;
    public Rigidbody2D rb;

    public void Start()
    {
        position = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float x = Input.GetAxis("Horizontal");
        position.Translate(new Vector3(x * 0.01f, 0, 0));
    }
}
