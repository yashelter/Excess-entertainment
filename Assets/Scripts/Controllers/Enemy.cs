using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyType ThisType;
    public EntityWeapon ThisWeapon;
    public GameObject RadiationGenerator;
    public float radiationTimer = 4f;

    private Transform playerTransform;
    private Transform thisTransform;
    SpriteRenderer spriteRenderer;

    public HealthBarEnemy Healthbar;
    public float[] to;
    private float maxStopTime = 3f;
    public float stopTime = 1f;
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
        to = new float[] { playerTransform.position.x, playerTransform.position.y };
    }

    public override void GetDamage(float x)
    {
        base.GetDamage(x);
        Healthbar.SetHealth(stats.Health, stats.MaxHealth);
    }
    protected void Update()
    {
        if (ThisType == EnemyType.katakirauva)
        {
            if (stopTime < 1.8f && stopTime > 0)
            {
                animations.SetBool("isRunning", true);
            }
            if (stopTime > 0)
            {
                stopTime -= Time.deltaTime;
                to = new float[] { playerTransform.position.x, playerTransform.position.y };
            }
            else
            {
                KatakirauvaEngine();
            }

        }

    }
    public void KatakirauvaEngine()
    {
        float[] direction = { 1, 1 };
        currRange += stats.speed * Time.deltaTime * 2;
        if (currRange > maxRange)
        {
            currRange = 0;
            stopTime = maxStopTime;
            direction = new float[] { 0, 0 };
        }
        if (to[0] < thisTransform.position.x) direction[0] *= -1;
        if (to[1] < thisTransform.position.y) direction[1] *= -1;

        Move(direction);
    }
    public void ActivateDamageRadious()
    {
        ThisWeapon.StartAttack();
    }
    public void DeActivateDamageRadious()
    {
        ThisWeapon.EndAttack();
    }
    public void UnderToxic()
    {
        if (radiationTimer > 0)
        {
            radiationTimer -= Time.deltaTime;
        }
        else
        {
            RadiationGenerator.SetActive(true);
        }
    }
    protected override void Die()
    {
        Alive = false;
        animations.SetTrigger("Die");
    }
    protected void Destroy()
    {
        Destroy(gameObject);
    }
}