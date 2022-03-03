using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Entity
{
    public HealthBar healthBar;

    public float speed = 2f;

    public BetterButton left, right, up, slide;

    public float jumpForce;
    public int jumps = 2;
    private int jumpsCount;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius;
    private bool isGrounded;

    protected override void Start()
    {
        base.Start();
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
        jumpsCount = jumps;
    }
    public void Update()
    {
        if (isGrounded == true)
        {
            jumpsCount = jumps;
        }

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
            Jump();
        }
        else
        {
            entityRidgidBody.velocity = (new Vector3(x * speed, entityRidgidBody.velocity.y, 0));
        }
        MovementAnimations(new float[] { x, y });
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    public void Jump()
    {
        jumpsCount--;

        if (jumpsCount > 0)
        {
            entityRidgidBody.velocity = Vector2.up * jumpForce;
        }    
        else if (jumpsCount == 0 && isGrounded)
        {
            entityRidgidBody.velocity = Vector2.up * jumpForce;
        }    
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
