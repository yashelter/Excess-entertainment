using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Entity
{
    public float speed = 2f;

    public BetterButton left, right, up, slide, attack;
    protected override void Start()
    {
        base.Start(); 
    }
    public void Update()
    {
        float x = 0, y = 0;
        if (left.isHold)
        {
            x = -1;
        }
        else if (right.isHold)
        {
            x = 1;
        }
        if (slide.isHold)
        {
            Slide();
        }
        if (up.isHold)
        {
            entityRidgidBody.velocity = (new Vector3(x * speed, 8, 0));
        }
        else
        {
            entityRidgidBody.velocity = (new Vector3(x * speed, entityRidgidBody.velocity.y, 0));
        }
        MovementAnimations(new float[] { x, y });
        
    }
    

}
