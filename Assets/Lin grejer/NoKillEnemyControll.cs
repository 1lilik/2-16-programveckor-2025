using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoKillEnemyControll : MonoBehaviour
{
    public Transform Target;
    float speed = 3f;
    bool AllowWalk;
    public float Pausetime;
    Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AllowWalk = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Kollar om fienden nuddat spelaren, om inte f�r fienden r�ra p� sig
        if (AllowWalk == true)
        {
            //Fienden r�r sig konststant mot spelarens position
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Om fienden nuddar spelaren slutar fienden r�ra p� sig efter en viss tid
        if (collision.gameObject.tag == ("Player"))
        {
            AllowWalk = false;
            Invoke("EnemyPause", Pausetime);
        } 
        //G�r s� att fienderna inte puttas bak�t om de blir nuddade av skotten
        //Innan detta till�gg b�rjade fienderna �ka bak�t om de blev tr�ffade av ett skott och de fortsatte tills de tr�ffade v�ggen
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


