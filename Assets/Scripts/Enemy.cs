using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyType ThisType;
    public Transform playerTransform;
    public Transform thisTransform;
    public enum EnemyType
    {
        minion, shooter, stayer
        
    };
    protected override void Start()
    {
        base.Start();
        playerTransform = FindObjectOfType<Player>().gameObject.transform;
        thisTransform = GetComponent<Transform>();
    }

    public override void GetDamage(int x)
    {
        base.GetDamage(x);
        Debug.Log(stats.Health);
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
