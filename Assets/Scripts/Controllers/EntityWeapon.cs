using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWeapon : PlayerWeapon
{
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().GetDamage(damage);
        }
    }
    
}
