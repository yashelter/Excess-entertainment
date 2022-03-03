using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool isAttacking = false;
    public List<GameObject> damaged = new List<GameObject>();
    public Controller player;
    public void Start()
    {
        player = FindObjectOfType<Controller>();
    }
    public void TriggerAttack()
    {
        StopAllCoroutines();
        StartCoroutine(DamageMod());
    }
    public IEnumerator DamageMod()
    {
        damaged = new List<GameObject>();
        yield return new WaitForSeconds(0.1f);
        isAttacking = true;
        yield return new WaitForSeconds(0.1f);
        isAttacking = false;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (isAttacking && collision.CompareTag("enemy") && !damaged.Contains(collision.gameObject))
        {
            damaged.Add(collision.gameObject);
            collision.GetComponent<Enemy>().getDamage(player.stats.damage);
        }
    }
}
