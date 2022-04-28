using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    public int Health = 100;
    public static int Health2 = 0;
    private float invulnerability = 1f;
    public int HealPlayerForKill = 2;
    public float start_invulnerability = 2f;
    private int scoreKills = 0;
    

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Health2 - scoreKills != 0) {
            scoreKills++;
            if (Health <= 98) Health += HealPlayerForKill;
        }

        if (Health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (invulnerability > 0) {
            invulnerability -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (invulnerability <= 0) {
            if (collision.gameObject.CompareTag("Enemy")) {
                Health -= 20;
                invulnerability = start_invulnerability;
            }
        }
        
    }
    
}
