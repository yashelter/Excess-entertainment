using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    
    public int maxHealth;
    public float health;
    public int defend;
    public float speed;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Health { get => health; set {  if (value < 0) health = 0; else if (value < MaxHealth) health = value; else health = maxHealth; } }


    public float getHealth() => Health;

    //public int[] getStats() => new int[] { Health, defend, speed }; // получаем массив статов
        
    
    

}
