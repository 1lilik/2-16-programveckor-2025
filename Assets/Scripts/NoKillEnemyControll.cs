using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoKillEnemyControll : MonoBehaviour
{
    public Transform Target;
    float speed = 3f;
    bool AllowWalk;
    Rigidbody2D rb;
    public Animator animator;
    SpriteRenderer spriteRenderer;
   
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AllowWalk = true;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //Kollar om fienden nuddat spelaren, om inte får fienden röra på sig
        if (AllowWalk == true)
        {
            //Fienden rör sig konststant mot spelarens position
            animator.Play("Enemy2_walking");
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

            if (Target.position.x - transform.position.x < 0)
            {
                
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Om fienden nuddar spelaren slutar fienden röra på sig efter en viss tid
        if (collision.gameObject.tag == ("Player"))
        {
            AllowWalk = false;
            Invoke("EnemyPause", 1);
            animator.Play("Enemy2_attack");

        } 
        //Gör så att fienderna inte puttas bakåt om de blir nuddade av skotten
        //Innan detta tillägg började fienderna åka bakåt om de blev träffade av ett skott och de fortsatte tills de träffade väggen
        if (collision.gameObject.tag == ("PlayerProjectile") || collision.gameObject.tag == ("NoKillEnemy"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void EnemyPause()
    {
        AllowWalk = true;
    }
}


