using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity // класс игрока
{
    public HealthBar healthBar;
    public PlayerWeapon weapon;

    protected override void Start()
    {
        base.Start(); // что-то €вно не так надо почитать про ќќѕ
        // что бы получить статы из других скриптов использовать stats.getStats(); получает => int[] 
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
        weapon = FindObjectOfType<PlayerWeapon>();

    }

    private void Update()
    {
        float[] input = new float[] { Input.GetAxis("Horizontal") * 4f, Input.GetAxis("Vertical") * 4f};
        // должна быть логика вли€ни€ предметов на статы? или решить по другому
        Move(input);
        if (Input.GetKey(KeyCode.Space) && IsSlided) Slide();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartAttack(); // в аниматоре нужно остановить атаку, работает на входе обектов в зону поражени€
                           // поэтому каждого забамажим ровно 1 раз, во врем€ атаки фризить поворот(и движени€ наверно тоже)
                           // !!сделать при по€влении спрайтов
        }
    }
    private void FixedUpdate()
    {
        healthBar.SetHealth(stats.getHealth());
    }
    private void StartAttack()
    {
        weapon.StartAttack();
    }
}
