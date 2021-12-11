using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity // ����� ������
{
    public HealthBar healthBar;
    public PlayerWeapon weapon;

    protected override void Start()
    {
        base.Start(); // ���-�� ���� �� ��� ���� �������� ��� ���
        // ��� �� �������� ����� �� ������ �������� ������������ stats.getStats(); �������� => int[] 
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
        weapon = FindObjectOfType<PlayerWeapon>();

    }

    private void Update()
    {
        float[] input = new float[] { Input.GetAxis("Horizontal") * 4f, Input.GetAxis("Vertical") * 4f};
        // ������ ���� ������ ������� ��������� �� �����? ��� ������ �� �������
        Move(input);
        if (Input.GetKey(KeyCode.Space) && IsSlided) Slide();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartAttack(); // � ��������� ����� ���������� �����, �������� �� ����� ������� � ���� ���������
                           // ������� ������� ��������� ����� 1 ���, �� ����� ����� ������� �������(� �������� ������� ����)
                           // !!������� ��� ��������� ��������
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
