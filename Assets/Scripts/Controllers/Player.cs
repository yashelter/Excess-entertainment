using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity // ����� ������
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
        if (!Alive) return;
        float[] input = new float[] { Input.GetAxis("Horizontal") * 4f, Input.GetAxis("Vertical") * 4f };
        // ������ ���� ������ ������� ��������� �� �����? ��� ������ �� �������
        Move(input);
        if (Input.GetKey(KeyCode.Space) && IsSlided) Slide();
        if (Input.GetKey(KeyCode.Mouse0) && IsSlided)
        {
            StartAttack(); // � ��������� ����� ���������� �����, �������� �� ����� ������� � ���� ���������
                           // ������� ������� ��������� ����� 1 ���, �� ����� ����� ������� �������(� �������� ������� ����)
                           // !!������� ��� ��������� ��������
        }

    }
    protected override void Die()
    {
        Alive = false;
        animations.SetTrigger("Die");
    }
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
