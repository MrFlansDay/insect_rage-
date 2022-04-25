using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHero : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Transform heroPos;
    public int bulletSpeed = 10;
    public float timeout = 0.5f;
    private float curTimeout;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            curTimeout += Time.deltaTime;
            if (curTimeout > timeout)
            {
                curTimeout = 0;
                Rigidbody2D bulletInstance = Instantiate(projectile, heroPos.position, Quaternion.identity) as Rigidbody2D;
                bulletInstance.velocity = heroPos.forward * bulletSpeed;
            }
        }
        else
        {
            curTimeout = timeout + 1;
        }
    }
}