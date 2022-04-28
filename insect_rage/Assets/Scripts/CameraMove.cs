using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        
        if (player) {
            if (player.position.y < 15.5f) {
                if (player.position.x > 8.88888888f) {
                    float temp = Mathf.Floor(axisX(player.position.x - 8.88888888f));
                    temp++;
                    transform.position = new Vector3(temp * 17.77777776f, transform.position.y, -10);
                }
                else if (player.position.x < (-8.88888888f)) {
                    float temp = Mathf.Floor(axisX(player.position.x + 8.88888888f));
                    transform.position = new Vector3(temp * 17.77777776f, transform.position.y, -10);
                }
                else {
                    transform.position = new Vector3(0, transform.position.y, -10);
                }

                if (player.position.y > 5f) {
                    float temp = Mathf.Floor(axisY(player.position.y - 5f));
                    temp++;
                    transform.position = new Vector3(transform.position.x, temp * 10f, -10);
                }
                else if (player.position.y < (-5f)) {
                    float temp = Mathf.Floor(axisY(player.position.y + 5f));
                    transform.position = new Vector3(transform.position.x, temp * 10f, -10);
                }
                else {
                    transform.position = new Vector3(transform.position.x, 0, -10);
                }
            }
            else {
                if (player.position.x < 8.5f & player.position.x > (-8.5f)) {
                    transform.position = new Vector3(player.position.x, transform.position.y, -10);
                }
                if (player.position.y < 30f & player.position.y > 20f) {
                    transform.position = new Vector3(transform.position.x, player.position.y, -10);
                }
            }
        }

    }

    float axisX(float x) {
        if (x != 0) {
            return Mathf.Floor(x / 17.77777776f);
        } else {
            return 0;
        }
    }
    float axisY(float y) {
        if (y != 0) {
            return Mathf.Floor(y / 10f);
        }
        else {
            return 0;
        }
    }
}
