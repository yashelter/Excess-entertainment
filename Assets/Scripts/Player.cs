using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity // ����� ������
{
    public HealthBar healthBar;

    protected override void Start()
    {
        base.Start(); // ���-�� ���� �� ��� ���� �������� ��� ���
        // ��� �� �������� ����� �� ������ �������� ������������ stats.getStats(); �������� => int[] 
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(100);
        
    }

    private void Update()
    {
        float[] input = new float[] { Input.GetAxis("Horizontal") * 4f, Input.GetAxis("Vertical") * 4f};
        // ������ ���� ������ ������� ��������� �� �����? ��� ������ �� �������
        Move(input);
        if (Input.GetKey(KeyCode.Space) && IsSlided) Slide();
    }
    private void FixedUpdate()
    {
        healthBar.SetHealth(stats.getHealth());
    }
}
