using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy = 0;
    public float dist;
    public int dmg = 50;
    public LayerMask barr;

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, dist, barr);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(dmg);
                Destroy(gameObject);
            }
            
        }
        timeToDestroy += Time.deltaTime;
        if (timeToDestroy >= 1) Destroy(gameObject);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}