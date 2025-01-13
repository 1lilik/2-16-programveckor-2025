using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject enemy;
    public float ProjMaxAliveTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Minskar tiden som projectilen �r levande tills den �r lika med eller mindre �n 0, d� f�rst�rs den
        ProjMaxAliveTime -= Time.deltaTime;
        if (ProjMaxAliveTime <=0)
        {
            PlayerShooting playershooting = FindObjectOfType<PlayerShooting>();
            playershooting.AllowToShoot = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            
            //Meddelar Enemyspawning skriptet att en fiende blivit tr�ffad av en projectile
            EnemySpawningWaves enemyManager = FindObjectOfType<EnemySpawningWaves>();
            enemyManager.OnEnemyHit(collision.gameObject);
            PlayerShooting playershooting = FindObjectOfType<PlayerShooting>();
            playershooting.AllowToShoot = true;
            //f�rst�r projektilen som tr�ffade fienden
            Destroy(gameObject);
        }
        //Om projectilen tr�ffar v�ggen f�rst�rs den
        if (collision.gameObject.tag == ("Border"))
        {
            PlayerShooting playershooting = FindObjectOfType<PlayerShooting>();
            playershooting.AllowToShoot = true;
            Destroy(gameObject);
        }
       
    }
}
