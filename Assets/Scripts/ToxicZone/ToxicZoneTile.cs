using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZoneTile : MonoBehaviour
{
    public float damage = .1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().GetDamage(damage);
        }
    }
    

}
