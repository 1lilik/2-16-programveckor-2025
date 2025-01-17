using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattacker : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private float damage;

    float timeUntilMelee;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        print("Playerattack update");
        if (timeUntilMelee <= 0f) //Trycker man p� v�nster musknapp s� svingar man sv�rdet
        {
            print("Inne i f�rsta if, melee time");

            if (Input.GetMouseButtonDown(0))
            {
                anim.Play("Playerattack", -1);
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
