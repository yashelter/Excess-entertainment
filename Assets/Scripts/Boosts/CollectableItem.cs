using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsCollected(collision.gameObject.GetComponent<Player>());
        }
    }
    public virtual void IsCollected(Player player) { }
        
}
