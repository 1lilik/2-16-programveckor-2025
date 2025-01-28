using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public Transform Target;
    public float speed;
    public bool AllowWalk;
    public int lives = 3;
    public Animator animator;
    Rigidbody2D Rigidbody;
    SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        //Sätter target som objektet som har "Player" taggen på sig
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AllowWalk = true;
        Rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //kollar om fienden nuddat spelaren, om inte får fienden röra på sig
        if (AllowWalk == true)
        {
            //Fienden rör sig konststant mot spelarens position
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            animator.Play("Enemy1_walking");
        }

        if (Target.position.x - transform.position.x < 0)
        {

            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Om fienden nuddar spelaren slutar fienden röra på sig efter en viss tid
        if (collision.gameObject.tag == ("Player"))
        {
            AllowWalk = false;
            animator.Play("Enemy1_attack");
            Invoke("EnemyPause", 1);
        }
        if (collision.gameObject.tag == ("Enemy") || collision.gameObject.tag == ("PlayerProjectile"))
        {
            Rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
    }

    public void EnemyPause()
    {
        AllowWalk = true;
    }
}

