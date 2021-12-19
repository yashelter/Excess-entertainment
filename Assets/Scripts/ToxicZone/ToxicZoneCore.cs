using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZoneCore : MonoBehaviour
{
    public GameObject tile;
    public Transform zoneStart;

    public int size = 5;

    public float tileSize = 1f;

    public GameObject[,] tileMap;

    void Start()
    {
        zoneStart = GetComponent<Transform>();
        tileMap = new GameObject[size,size];
        ClearZone();
        GenerateZone();
        StartCoroutine(ReGenerate());
    }

    private IEnumerator ReGenerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            ClearZone();
            GenerateZone();
        }
    }
    public void GenerateZone()
    {
        float[] positionStart = { zoneStart.position.x - (size / 2 * tileSize), zoneStart.position.y + (size / 2 * tileSize) };
        float[] position = (float[]) positionStart.Clone();
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < size; i++)
            {
                 tileMap[j, i] = Instantiate(tile, new Vector2(position[0], position[1]), Quaternion.identity);
                 tileMap[j, i].GetComponent<ToxicZoneTile>().parent = gameObject;
                 position[0] += tileSize;
            }
            position[1] = position[1] - tileSize;
            position[0] = positionStart[0];
        }
        
    }
    public void ClearZone()
    {
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < size; i++)
            {
                Destroy(tileMap[j, i]);
            }
        }
        
    }
}
