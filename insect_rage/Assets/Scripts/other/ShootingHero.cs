using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHero : MonoBehaviour
{
    public float angle = -90f;
    public GameObject bullet;
    public Transform heroPos;

    private float reload;
    public float startReload = 0.5f;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + angle);

        if (reload <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, heroPos.position, transform.rotation);
                reload = startReload;
            }
        }
        else
        {
            reload -= Time.deltaTime;
        }
    }
}