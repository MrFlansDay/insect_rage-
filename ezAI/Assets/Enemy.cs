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

    public int Health = 100;
    private GameObject player;// íàø ïåðñîíàæ
    public int rotationSpeed; //ïåðåìåííàÿ ñêîðîñòè ïîâîðîòà
    public Transform target; // íà ýòîò îáúåêò áóäåò ðåàãèðîâàòü íàø âðàã
    private Transform myTransform; // êîîðäèíàòû âðàãà
 
 
  public void Death()
    {
        if(Health == 0)
        {
            Destroy(gameObject);
        }
    }
 

    private void Awake()
    {
        this.myTransform = base.transform; //îïðåäåëÿåì òåêóùåå ïîëîæåíèå âðàãà
        this.player = GameObject.FindGameObjectWithTag("Player"); // îïðåäåëÿåì îáúåêò íà êîòîðûé áóäåò ðåàãèðîâàòü âðàã
        this.target = player.transform;
    }



    private void FixedUpdate()
    {


        if (this.player != null)
        {
            float num = Vector3.Distance(base.transform.position, this.player.transform.position); // åñëè äèñòàíöèÿ äî ïåðñîíàæà áóäåò ìåíüøå 8, òî âðàã áóäåò äâèãàòüñÿ â ñòîðîíó ïåðñîíàæà
            if (num < 8f && num > 3f)
            {
                this._attack = 0f;
                this._vert = 2f;
                this.rotationSpeed = 3;
                this.myTransform.rotation = Quaternion.Lerp(this.myTransform.rotation, Quaternion.LookRotation(this.target.position - this.myTransform.position,Vector3.up), (float)this.rotationSpeed * Time.deltaTime);
                this._stun = false;
                this.myTransform.position += this.myTransform.forward * ((float)this.rotationSpeed * Time.deltaTime);
            }
            if (num >= 5f) //åñëè áîëüøå, âðàã áóäåò ñòîÿòü
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
    
    
     private void OnColliderEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Bullet")
        {
            Health -= 20;
        }
    }
}
