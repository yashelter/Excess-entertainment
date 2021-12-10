using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 1;
    private IEnumerator coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coroutine = Damage(collision.gameObject);
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator Damage(GameObject gameObject)
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Player>().GetDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(coroutine);
        }
    }
}
