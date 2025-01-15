using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public Transform Target;
    float speed = 3f;
    public bool AllowWalk;
    public int lives = 3;
    public Animator Animator;
    Rigidbody2D Rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        //Sätter target som objektet som har "Player" taggen på sig
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AllowWalk = true;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //kollar om fienden nuddat spelaren, om inte får fienden röra på sig
        if (AllowWalk == true)
        {
            //Fienden rör sig konststant mot spelarens position
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            Animator.Play("Enemy1_walking");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Om fienden nuddar spelaren slutar fienden röra på sig efter en viss tid
        if (collision.gameObject.tag == ("Player"))
        {
            AllowWalk = false;
            Animator.Play("Enemy1_attack");
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

    public void TakeDamage()
    {

    }

}
