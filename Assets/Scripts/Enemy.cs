using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform leftPoint;
    public Transform rightPoint;

    public bool way = true;

    public void FixedUpdate()
    {
        if (way)
        {
            entityTransform.Translate(new Vector3(-stats.speed*0.01f, 0));
            if (entityTransform.position.x < leftPoint.position.x)
            {
                way = false;
            }
        }
        else
        {
            entityTransform.Translate(new Vector3(stats.speed * 0.01f, 0, 0));
            if (entityTransform.position.x > rightPoint.position.x)
            {
                way = true;
            }
        }
        
    }
}