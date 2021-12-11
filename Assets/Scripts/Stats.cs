using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    
    public int maxHealth;
    public int health;
    public int defend;
    public float speed;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Health { get => health; set { if (value < MaxHealth) health = value; else health = maxHealth; } }

    public int getHealth() => Health;

    //public int[] getStats() => new int[] { Health, defend, speed }; // получаем массив статов
        
    
    

}
