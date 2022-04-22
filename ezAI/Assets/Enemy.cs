using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    

    [SerializeField] private float _horiz;
    [SerializeField] private float _vert;
    [SerializeField] private float _attack;
    [SerializeField] private bool _stun;
    [SerializeField] public bool _death;


    private GameObject player;// ��� ��������
    public int rotationSpeed; //���������� �������� ��������
    public Transform target; // �� ���� ������ ����� ����������� ��� ����
    private Transform myTransform; // ���������� �����
 

    private void Awake()
    {
        this.myTransform = base.transform; //���������� ������� ��������� �����
        this.player = GameObject.FindGameObjectWithTag("Player"); // ���������� ������ �� ������� ����� ����������� ����
        this.target = player.transform;
    }



    private void FixedUpdate()
    {


        if (this.player != null)
        {
            float num = Vector3.Distance(base.transform.position, this.player.transform.position); // ���� ��������� �� ��������� ����� ������ 8, �� ���� ����� ��������� � ������� ���������
            if (num < 8f && num > 3f)
            {
                this._attack = 0f;
                this._vert = 2f;
                this.rotationSpeed = 3;
                this.myTransform.rotation = Quaternion.Lerp(this.myTransform.rotation, Quaternion.LookRotation(this.target.position - this.myTransform.position,Vector3.up), (float)this.rotationSpeed * Time.deltaTime);
                this._stun = false;
                this.myTransform.position += this.myTransform.forward * ((float)this.rotationSpeed * Time.deltaTime);
            }
            if (num >= 5f) //���� ������, ���� ����� ������
            {
                this._attack = 0f;
                this._stun = true;
            }

            if (num <= 1.2f)
            {
                this._vert = 0f;
                this._attack = 20f;
                this._stun = false;
            }
        }
    }
}