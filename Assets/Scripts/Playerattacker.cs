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
        if (timeUntilMelee <= 0f) //Trycker man på vänster musknapp så svingar man svärdet
        {
            print("Inne i första if, melee time");

            if (Input.GetMouseButtonDown(0))
            {
                anim.Play("Playerattack", -1);
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
