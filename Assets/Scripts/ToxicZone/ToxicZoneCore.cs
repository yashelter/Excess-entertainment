using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZoneCore : MonoBehaviour
{
    public GameObject tile;
    public Transform zoneStart;

    public float zoneDamage = .1f;
    public int size = 5;

    public float tileSize = 1f;

    public GameObject[,] tileMap;

    void Start()
    {
        tile.GetComponent<ToxicZoneTile>().damage = zoneDamage;
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
            yield return new WaitForSeconds(0.1f);
            ClearZone();
            GenerateZone();
        }
    }
    public void GenerateZone()
    {
        float[] positionStart = { zoneStart.position.x - (size / 2 * tileSize), zoneStart.position.y + (size / 2 * tileSize) };

        float[] position = (float[])positionStart.Clone();
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < size; i++)
            {
                var hits = Physics2D.BoxCastAll(zoneStart.position, tile.transform.localScale, 0, new Vector3(position[0], position[1]) - zoneStart.position);
                var hasWallOnPath = false;
                Barier b = null;
                for (int k = 0; k < hits.Length; k++)
                {
                    if (hits[k].collider.CompareTag("Wall"))
                    {
                        b = hits[k].collider.GetComponent<Barier>();
                        hasWallOnPath = true;
                        break;
                    }
                }
                tileMap[j, i] = Instantiate(tile, new Vector2(position[0], position[1]), Quaternion.identity);
                if (hasWallOnPath)
                {
                    Color c = tileMap[j, i].GetComponent<SpriteRenderer>().color;
                    c.a -= b.minusAlthaValue;
                    tileMap[j, i].GetComponent<ToxicZoneTile>().damage -= b.minusDmgValue;
                    tileMap[j, i].GetComponent<SpriteRenderer>().color = c;
                }


                position[0] += tileSize;
            }
            position[1] = position[1] - tileSize;
            position[0] = positionStart[0];
        }
        int x = (size - 1) / 2;
        for (int j = 0; j < size; j++)
        {
            for (int i = 0; i < size; i++)
            {
                int d = Mathf.Max(Mathf.Abs(x - i), Mathf.Abs(x - j));
                Color c = tileMap[j, i].GetComponent<SpriteRenderer>().color;
                c.a -= (size / 2 + 1f) / 10 * d;
                
                tileMap[j, i].GetComponent<ToxicZoneTile>().damage *= (1 - (size / 2 + 1f) / 10 * d);
                tileMap[j, i].GetComponent<SpriteRenderer>().color = c;
                
            }
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
