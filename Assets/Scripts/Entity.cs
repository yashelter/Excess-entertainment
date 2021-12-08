using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour // базовый класс всего
{
   
    public Transform entityTransform { get; private set; }
    public Rigidbody2D entityRidgidBody { get; private set; }
    public Stats stats { get; protected set; }
    
    protected Animator animations;
    private InGameManager gameManager;

    private bool isSlided;
    private bool isRotated;
    private float slideTimer = 0f;
    private float slideTimerMaxValue = 1f; 

    public bool IsSlided { get => isSlided; set => isSlided = value; }
    private float entitySpeed = 2f;
    private float slideBoost = 1.3f;

    protected virtual void Start()
    {
        entityTransform = GetComponent<Transform>();
        gameManager = FindObjectOfType<InGameManager>();
        animations = GetComponent<Animator>();
        entityRidgidBody = GetComponent<Rigidbody2D>();
        stats = new Stats(100, 100); // должны ставиться сохранённые данные
        isRotated = false;
        IsSlided = true;
    }

    protected void Move(float[] direction)
    {   
        if (!gameManager.gameActive) return;
        if ((direction[0] < 0 && !isRotated) || (direction[0] > 0 && isRotated)) Flip();
        //if (isRotated) direction[0] *= -1;
        if(slideTimer > 0) slideTimer -= Time.deltaTime;
        entityRidgidBody.velocity = new Vector3(direction[0] * entitySpeed, direction[1] * entitySpeed, 0);
        Animations(direction);
    }
    protected void Animations(float[] direction)
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
    }
    protected void Slide()
    {
        if (slideTimer <= 0) animations.SetTrigger("Slide");
    }

    protected void Die() => Destroy(gameObject);
    public void GetDamage(int damage) => stats.Health = stats.Health - damage;
    public void StartSlide() 
    { 
        IsSlided = false;
        entitySpeed += slideBoost;
    }
    public void EndSlide() 
    {
        IsSlided = true;
        slideTimer = slideTimerMaxValue;
        entitySpeed -= slideBoost;
    }
    

}
