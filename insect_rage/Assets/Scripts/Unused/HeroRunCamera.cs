using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRunCamera : MonoBehaviour {

    private Transform player;

    // Start is called before the first frame update
    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate() {
        Vector3 temp = transform.position;
        temp.y = player.position.y;
        temp.x = player.position.x;

        transform.position = temp;
    }
}
