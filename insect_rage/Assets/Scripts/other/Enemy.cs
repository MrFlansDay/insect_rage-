using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {


    [SerializeField] private float _horiz;
    [SerializeField] private float _vert;
    [SerializeField] private float _attack;
    [SerializeField] private bool _stun;
    [SerializeField] public bool _death;

    public int Health = 100;
    private GameObject player;
    public int rotationSpeed;
    public Transform target;
    private Transform myTransform;


    private void Update() {
        if (Health <= 0) {
            PlayerDeath.Health2++;
            Destroy(gameObject);
        }
    }


    private void Awake() {
        this.myTransform = base.transform;
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.target = player.transform;
    }



    private void FixedUpdate() {


        if (this.player != null) {
            float num = Vector3.Distance(base.transform.position, this.player.transform.position);

            if (num < 8f && num > 0.5f) {
                this._attack = 0f;
                this._vert = 2f;
                this.rotationSpeed = 3;
                Vector3 moveDirection = player.transform.position - transform.position;
                if (moveDirection != Vector3.zero) {
                    float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
                //this.myTransform.rotation = Quaternion.Lerp(this.myTransform.rotation, Quaternion.LookRotation(this.target.position - this.myTransform.position, Vector3.up), (float)this.rotationSpeed * Time.deltaTime);
                this._stun = false;
                this.myTransform.position += this.myTransform.up * ((float)this.rotationSpeed * Time.deltaTime);
            }

            if (num >= 5f) {
                this._attack = 0f;
                this._stun = true;
            }

            if (num <= 2f) {
                this._vert = 0f;
                this._attack = 20f;
                this._stun = false;
            }
        }

    }


    public void TakeDamage(int dmg) {
        Health -= dmg;
    }
}
