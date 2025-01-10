using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;
    public float speed = 3f;
    bool AllowWalk = true;
    public float Pausetime;


    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowWalk == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
