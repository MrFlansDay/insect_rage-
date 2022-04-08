using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementHor = Input.GetAxis("Horizontal");
        float movementVer = Input.GetAxis("Vertical");
        transform.position += new Vector3(movementHor, movementVer, 0) * speed * Time.deltaTime;

    }
}
