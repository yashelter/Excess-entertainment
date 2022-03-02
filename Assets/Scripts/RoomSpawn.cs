using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        None
    }

    private RoomVariants variants;
    private int rand;
    private static int spawned = 4; // ���-�� ������
    private float waitTime = 3f;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Debug.Log(variants);
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.2f);
    }
    
    public void Spawn()
    {
        if (spawned < 0)
        {
            CancelInvoke("Spawn");
            return;
        }
        spawned--;
        Debug.Log(variants);
        if(direction == Direction.Top)
        {
            rand = Random.Range(0, variants.topRooms.Length);
            Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
        }
        else if(direction == Direction.Bottom)
        {
            rand = Random.Range(0, variants.bottomRooms.Length);
            Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
        }
        else if (direction == Direction.Right)
        {
            rand = Random.Range(0, variants.rightRooms.Length);
            Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
        }
        else if (direction == Direction.Left)
        {
            rand = Random.Range(0, variants.leftRooms.Length);
            Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
        }   
    }
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("RoomPoint"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
