using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public Transform Target;
    public float speed = 3f;
    bool AllowWalk;
    public float Pausetime;
    public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        //Sätter target som objektet som har "Player" taggen på sig
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AllowWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        //kollar om fienden nuddat spelaren, om inte får fienden röra på sig
        if (AllowWalk == true)
        {
            //Fienden rör sig konststant mot spelarens position
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);   
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Om fienden nuddar spelaren slutar fienden röra på sig efter en viss tid
        if (collision.gameObject.tag == ("Player"))
        {
            AllowWalk = false;
            Invoke("EnemyPause", Pausetime);
        }
        else if(collision.gameObject.tag == ("PlayerProjectile"))
        {
            //Om fienden nuddar en projectile förstörs fienden
            lives -= 1;
            if (lives <= 0) 
            {
                Destroy(gameObject);
            }
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
