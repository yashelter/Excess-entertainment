using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    protected override void Start()
    {
        base.Start();
    }

    public override void GetDamage(int x)
    {
        base.GetDamage(x);
        Debug.Log(stats.Health);
    }
}
