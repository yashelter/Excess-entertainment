using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform leftPoint;
    public Transform rightPoint;

    public bool way = true;
    public int damage = 10;

   // public HealthBarEnemy Healthbar;

    protected override void Start()
    {
        base.Start();
        stats.HealthPoint = 30;
        //Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void FixedUpdate()
    {
        if (way)
        {
            entityTransform.Translate(new Vector3(-stats.speed*0.01f, 0));
            if (entityTransform.position.x < leftPoint.position.x)
            {
                way = false;
                Flip();
            }
        }
        else
        {
            entityTransform.Translate(new Vector3(stats.speed * 0.01f, 0, 0));
            if (entityTransform.position.x > rightPoint.position.x)
            {
                way = true;
                Flip();
            }
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
            collision.GetComponent<Controller>().getDamage(damage);
        }
    }
}