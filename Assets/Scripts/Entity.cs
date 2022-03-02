using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour 
{

    public Transform entityTransform { get; protected set; }
    public Rigidbody2D entityRidgidBody { get; protected set; }

    protected Animator animations;

    private bool isSlided = false;
    private bool isRotated = false;
    private float slideTimer = 0f;
    private float slideTimerMaxValue = 1f;

    public bool IsSlided { get => isSlided; set => isSlided = value; }
   
    protected bool Alive = true;

    public float slideBoost = 1.3f;
    public Stats stats;

    protected virtual void Start()
    {
        entityTransform = GetComponent<Transform>();
        entityRidgidBody = GetComponent<Rigidbody2D>();
        animations = GetComponent<Animator>();
        stats = new Stats();
    }

    protected void MovementAnimations(float[] direction)
    {
        if (direction[0] != 0)
        {
            animations.SetBool("isRunning", true);
        }
        else
        {
            animations.SetBool("isRunning", false);
        }
        if(direction[1] > 0)
        {
            animations.SetTrigger("Jump");

        }
        if (direction[0] > 0 && isRotated || direction[0] < 0 && !isRotated) Flip();
    }
    protected virtual void Flip()
    {
        isRotated = !isRotated;
        entityTransform.localScale = new Vector3(-entityTransform.localScale.x, entityTransform.localScale.y, 0);
    }
    protected void Slide()
    {
        if (slideTimer <= 0) animations.SetTrigger("Slide");
    }

    public void StartSlide()
    {
        IsSlided = false;
        stats.speed += slideBoost;
    }
    public void EndSlide()
    {
        IsSlided = true;
        slideTimer = slideTimerMaxValue;
        stats.speed -= slideBoost;
    }
    public void Attack()
    {
        // there must be logic
        animations.SetTrigger("Attack");
    }


}
