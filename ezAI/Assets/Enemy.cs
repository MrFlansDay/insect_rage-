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


    private GameObject player;// наш персонаж
    public int rotationSpeed; //переменная скорости поворота
    public Transform target; // на этот объект будет реагировать наш враг
    private Transform myTransform; // координаты врага
 

    private void Awake()
    {
        this.myTransform = base.transform; //определяем текущее положение врага
        this.player = GameObject.FindGameObjectWithTag("Player"); // определяем объект на который будет реагировать враг
        this.target = player.transform;
    }



    private void FixedUpdate()
    {


        if (this.player != null)
        {
            float num = Vector3.Distance(base.transform.position, this.player.transform.position); // если дистанция до персонажа будет меньше 8, то враг будет двигаться в сторону персонажа
            if (num < 8f && num > 3f)
            {
                this._attack = 0f;
                this._vert = 2f;
                this.rotationSpeed = 3;
                this.myTransform.rotation = Quaternion.Lerp(this.myTransform.rotation, Quaternion.LookRotation(this.target.position - this.myTransform.position,Vector3.up), (float)this.rotationSpeed * Time.deltaTime);
                this._stun = false;
                this.myTransform.position += this.myTransform.forward * ((float)this.rotationSpeed * Time.deltaTime);
            }
            if (num >= 5f) //если больше, враг будет стоять
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