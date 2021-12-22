using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public bool isSeen = false;
    public int maxEnemyValue = 3;

    public GameObject katakirauva;
    //public GameObject[] enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isSeen)
        {
            SpawnEnemies();
            isSeen=true;
        }
    }
    private void SpawnEnemies()
    {
        int cnt = Random.Range(1, maxEnemyValue);
        for (int i = 0; i < cnt; i++)
        {
            Instantiate(katakirauva, gameObject.transform.position, Quaternion.identity);
        }
        
    }
}
