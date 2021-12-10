using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    private int maxHealth;
    private int health;
    private int defend;
    private int speed;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Health { get => health; set { if (value < MaxHealth) health = value; else health = maxHealth; } }

    public Stats(int health, int maxHealth, int defend=0, int speed=0)
    {
        this.maxHealth = maxHealth;
        Health = health;
        this.defend = defend;
        this.speed = speed;

    }
    public int getHealth() => Health;

    public int[] getStats() => new int[] { Health, defend, speed }; // получаем массив статов
        
    
    

}
