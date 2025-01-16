using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattacker : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private float damage;

    float timeUntilMelee;

    private void Update()
    {
        
        if (timeUntilMelee <= 0f) //Trycker man på vänster musknapp så svingar man svärdet
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("loop körs");

                animator.Play("Playerattack");
                timeUntilMelee = meleeSpeed; //Cooldown på att svinga med svärdet

              
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")   //Gör så att svärdet kan döda fiender
        {
            EnemySpawningWaves enemyManager = FindObjectOfType<EnemySpawningWaves>();
            enemyManager.OnEnemyHit(other.gameObject);
            Debug.Log("Hit");
        }
    }
}
