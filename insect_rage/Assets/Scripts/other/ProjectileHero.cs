using UnityEngine;
using System.Collections;

public class ProjectileHero : MonoBehaviour
{

    public float damage = 1;
    public string[] targetTags = { "Target_1", "Target_2" };

    void OnTriggerEnter(Collider coll)
	{
		foreach (string currentTag in targetTags)
		{
			if (currentTag == coll.transform.tag)
			{
				coll.transform.GetComponent<Enemy>().AddDamage(damage);
			}
		}
		Destroy(gameObject);
	}
}