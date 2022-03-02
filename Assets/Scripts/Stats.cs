using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stats
{
    public float speed = 8f;
    public int maxHP = 100;

    private int healthPoint = 100;
    public int HealthPoint
    {
        get { return healthPoint; }
        set { if (value < 0) healthPoint = 0; else healthPoint = value; }
    }
    
    public int ourXP = 0;
    public int ourLevel = 0;
    public int needXP = 100;

}
