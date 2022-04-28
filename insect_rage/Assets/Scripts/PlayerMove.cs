using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        

        Vector3 move = GetBaseInput();
        if (move.sqrMagnitude > 0) {
            transform.position += move * speed * Time.deltaTime;
        }
        if (move.x < 0) {
            sr.flipX = true;
        } else if (move.x > 0){
            sr.flipX = false;
        }

    }

    private Vector3 GetBaseInput() { 
        Vector3 move_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W)) {
            move_Velocity += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.S)) {
            move_Velocity += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.A)) {
            move_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            move_Velocity += new Vector3(1, 0, 0);
        }
        return move_Velocity;
    }

   

}
