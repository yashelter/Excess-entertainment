using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicZoneTile : MonoBehaviour
{
    public float damage = 1;

    public GameObject parent;

    private IEnumerator coroutine;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(coroutine);
        }
    }
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
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Player>().GetDamage(damage);
        }
    }

}
