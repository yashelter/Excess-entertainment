using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int damage = 1;
    private BoxCollider2D hitZone;
    private void Start()
    {
        hitZone = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    }
    public void StartAttack()
    {
        hitZone.enabled = true;
    }
    public void EndAttack()
    {
        hitZone.enabled = false;
    }
}
