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
        
        if (timeUntilMelee <= 0f) //Trycker man p� v�nster musknapp s� svingar man sv�rdet
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("loop k�rs");

                animator.Play("Playerattack");
                timeUntilMelee = meleeSpeed; //Cooldown p� att svinga med sv�rdet

              
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")   //G�r s� att sv�rdet kan d�da fiender
        {
            EnemySpawningWaves enemyManager = FindObjectOfType<EnemySpawningWaves>();
            enemyManager.OnEnemyHit(other.gameObject);
            Debug.Log("Hit");
        }
    }
}
