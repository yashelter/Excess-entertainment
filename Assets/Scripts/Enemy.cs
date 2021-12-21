using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyType ThisType;
    private Transform playerTransform;
    private Transform thisTransform;
    SpriteRenderer spriteRenderer;

    public HealthBarEnemy Healthbar;

    private float maxStopTime = 3f;
    public float stopTime = 0f;
    private float maxRange;
    public float currRange = 0f;
    public enum EnemyType
    {
        katakirauva, shooter, stayer

    };
    protected override void Start()
    {
        base.Start();
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        thisTransform = GetComponent<Transform>();
        maxRange = stats.speed * 3;
        stats.Health = stats.MaxHealth;
        Healthbar.SetHealth(stats.Health, stats.MaxHealth);
    }

    public override void GetDamage(float x)
    {
        base.GetDamage(x);
        Healthbar.SetHealth(stats.Health, stats.MaxHealth);
    }
    protected void Update()
    {
        if(ThisType == EnemyType.katakirauva)
        {
            if(stopTime < 1.8f && stopTime > 0)
            {
                animations.SetBool("isRunning", true);
            }
            if (stopTime > 0)
            {
                stopTime -= Time.deltaTime;
            }
            else
            {
                KatakirauvaEngine();
            }
            
        }
        
    }
    public void KatakirauvaEngine()
    {
        float[] to = { playerTransform.position.x, playerTransform.position.y };
        float[] direction = { 1, 1 };
        currRange += stats.speed * Time.deltaTime * 2;
        if (currRange > maxRange)
        {
            currRange = 0;
            stopTime = maxStopTime;
            direction = new float[] {0,0};
        }
        
        if (to[0] < thisTransform.position.x) direction[0] *= -1;
        if (to[1] < thisTransform.position.y) direction[1] *= -1;

        Move(direction);
    }
}