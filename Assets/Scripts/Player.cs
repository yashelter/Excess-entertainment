using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity // класс игрока
{

    [HideInInspector]
    public HealthBar healthBar;
    private PlayerWeapon weapon;

    protected override void Start()
    {
        base.Start();
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
        weapon = FindObjectOfType<PlayerWeapon>();

    }

    private void Update()
    {
        float[] input = new float[] { Input.GetAxis("Horizontal") * 4f, Input.GetAxis("Vertical") * 4f};
        // должна быть логика влияния предметов на статы? или решить по другому
        Move(input);
        if (Input.GetKey(KeyCode.Space) && IsSlided) Slide();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartAttack(); // в аниматоре нужно остановить атаку, работает на входе обектов в зону поражения
                           // поэтому каждого задамажим ровно 1 раз, во время атаки фризить поворот(и движения наверно тоже)
                           // !!сделать при появлении спрайтов
        }
        
    }
    private void FixedUpdate()
    {
        healthBar.SetHealth((int)stats.getHealth());
    }
    private void StartAttack()
    {
        animations.SetTrigger("Attack");
        weapon.PlaySound();
    }
    public void GiveDamage()
    {
        weapon.StartAttack();
    }
    public void EndAttack()
    {
        weapon.EndAttack();
    }


}
