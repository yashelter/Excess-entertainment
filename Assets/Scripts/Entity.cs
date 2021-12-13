using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour // базовый класс всего
{
   
    public Transform entityTransform { get; private set; }
    public Rigidbody2D entityRidgidBody { get; private set; }

    public Stats stats;
    
    protected Animator animations;
    private InGameManager gameManager;

    private bool isSlided;
    private bool isRotated;
    private float slideTimer = 0f;
    private float slideTimerMaxValue = 1f; 

    public bool IsSlided { get => isSlided; set => isSlided = value; }
    private float slideBoost = 1.3f;

    protected virtual void Start()
    {
        entityTransform = GetComponent<Transform>();
        gameManager = FindObjectOfType<InGameManager>();
        animations = GetComponent<Animator>();
        entityRidgidBody = GetComponent<Rigidbody2D>();
       // stats = new Stats(); // должны ставиться сохранённые данные
        isRotated = false;
        IsSlided = true;
    }

    protected void Move(float[] direction)
    {   
        if (!gameManager.gameActive) return;
        if ((direction[0] < 0 && !isRotated) || (direction[0] > 0 && isRotated)) Flip();
        if(slideTimer > 0) slideTimer -= Time.deltaTime;
        entityRidgidBody.velocity = new Vector3(direction[0] * stats.speed, direction[1] * stats.speed, 0);
        MovementAnimations(direction);
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
    }
    protected void Flip()
    {
        isRotated = !isRotated;
        entityTransform.localScale = new Vector3(-entityTransform.localScale.x, entityTransform.localScale.y, 0);
        Debug.Log(entityTransform.localScale);
    }
    protected void Slide()
    {
        if (slideTimer <= 0) animations.SetTrigger("Slide");
    }
    protected void Die() => Destroy(gameObject);
    public virtual void GetDamage(float damage) => stats.Health = stats.Health - damage;
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

    

}
