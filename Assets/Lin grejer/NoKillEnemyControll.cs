using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoKillEnemyControll : MonoBehaviour
{
    public Transform Target;
    public float speed = 3f;
    bool AllowWalk;
    public float Pausetime;
   
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AllowWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        // kollar om fienden nuddat spelaren, om inte f�r fienden r�ra p� sig
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
    }

    public void EnemyPause()
    {
        AllowWalk = true;
    }
}


