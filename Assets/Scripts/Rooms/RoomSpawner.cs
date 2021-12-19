using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;
    public RoomVariants variants;
    public int rand;
    public bool spawned = false;
    private float waitTime = 3f;

    public enum Direction
    {
        Left, Bottom, Right, Top, None
    }
    public void Start()
    {
        variants = FindObjectOfType<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    }
    public void Spawn()
    {
        if (!spawned)
        {
            switch (direction)
            {
                case Direction.Top:
                    rand = Random.Range(0, variants.TopRooms.Length);
                    Instantiate(variants.TopRooms[rand], transform.position, variants.TopRooms[rand].transform.rotation);
                    break;
                case Direction.Bottom:
                    rand = Random.Range(0, variants.DownRooms.Length);
                    Instantiate(variants.DownRooms[rand], transform.position, variants.DownRooms[rand].transform.rotation);
                    break;
                case Direction.Left:
                    rand = Random.Range(0, variants.LeftRooms.Length);
                    Instantiate(variants.LeftRooms[rand], transform.position, variants.LeftRooms[rand].transform.rotation);
                    break;
                case Direction.Right:
                    rand = Random.Range(0, variants.RightRooms.Length);
                    Instantiate(variants.RightRooms[rand], transform.position, variants.RightRooms[rand].transform.rotation);
                    break;
            }
            spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RoomPoint") && collision.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
