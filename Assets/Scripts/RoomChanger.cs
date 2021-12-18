using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanger : MonoBehaviour
{
    public Vector3 changePosPlayer;
    public Vector3 changePosCamera;

    private Camera cam;

    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position += changePosPlayer;
            cam.transform.position += changePosCamera;
        }
    }
}
