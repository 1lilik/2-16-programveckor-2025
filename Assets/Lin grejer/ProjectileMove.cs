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
        //Minskar tiden som projectilen är levande tills den är lika med eller mindre än 0, då förstörs den
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
            
            //Meddelar Enemyspawning skriptet att en fiende blivit träffad av en projectile
            EnemySpawningWaves enemyManager = FindObjectOfType<EnemySpawningWaves>();
            enemyManager.OnEnemyHit(collision.gameObject);
            PlayerShooting playershooting = FindObjectOfType<PlayerShooting>();
            playershooting.AllowToShoot = true;
            //förstör projektilen som träffade fienden
            Destroy(gameObject);
        }
        //Om projectilen träffar väggen förstörs den
        if (collision.gameObject.tag == ("Border"))
        {
            PlayerShooting playershooting = FindObjectOfType<PlayerShooting>();
            playershooting.AllowToShoot = true;
            Destroy(gameObject);
        }
       
    }
}
