using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity // класс игрока
{
    public HealthBar healthBar;

    protected override void Start()
    {
        base.Start(); // что-то явно не так надо почитать про ООП
        // что бы получить статы из других скриптов использовать stats.getStats(); получает => int[] 
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
        
    }

    private void Update()
    {
        float[] input = new float[] { Input.GetAxis("Horizontal") * 4f, Input.GetAxis("Vertical") * 4f};
        // должна быть логика влияния предметов на статы? или решить по другому
        Move(input);
        if (Input.GetKey(KeyCode.Space) && IsSlided) Slide();
    }
    private void FixedUpdate()
    {
        healthBar.SetHealth(stats.getHealth());
    }
}
