using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Entity
{
    public HealthBar healthBar;

    public float speed = 2f;

    public BetterButton left, right, up, slide;

    protected override void Start()
    {
        base.Start();
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
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
    public void levelUP()
    {
        stats.ourXP = 0;
        stats.ourLevel++;
        // Maxims's formules
        stats.maxHP = (int) (stats.maxHP * 1.05f);
        stats.HP = stats.maxHP;
        stats.needXP = (int)(stats.needXP * 1.25f);
        animations.SetTrigger("Level Up");
    }


}
