using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyType ThisType;
    public Transform playerTransform;
    public Transform thisTransform;

    public HealthBarEnemy Healthbar;

    public enum EnemyType
    {
        minion, shooter, stayer
        
    };
    protected override void Start()
    {
        base.Start();
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        thisTransform = GetComponent<Transform>();

        stats.Health = stats.MaxHealth;
        Healthbar.SetHealth(stats.Health, stats.MaxHealth);
    }

    public override void GetDamage(float x)
    {
        base.GetDamage(x);
        Healthbar.SetHealth(stats.Health, stats.MaxHealth);
    }
    protected void FixedUpdate()
    {
        MinionEngine();
    }
    public void MinionEngine()
    {
        float[] to = { playerTransform.position.x, playerTransform.position.y };
        float[] direction = { 1, 1 };
        if (to[0] < thisTransform.position.x) direction[0] *= -1;
        if (to[1] < thisTransform.position.y) direction[1] *= -1;
        Move(direction);
    }
}
