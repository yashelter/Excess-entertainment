using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyType ThisType;
    public Transform playerTransform;
    public Transform thisTransform;

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HealthBarEnemy Healthbar;

    public enum EnemyType
    {
        minion, shooter, stayer
        
    };
    protected override void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        base.Start();
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        thisTransform = GetComponent<Transform>();
    }

    public override void GetDamage(float x)
    {
        base.GetDamage(x);
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
