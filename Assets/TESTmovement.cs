using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTmovement : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       

    }
    void Update()
    {
        transform.position = player.transform.position;
        animator.Play("Player_idle");

        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        { 
            //WalkingAnimation();
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            //WalkingAnimation();
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            //WalkingAnimation();
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            //WalkingAnimation();
        }
        else
        {
            //animator.Play("Player_idle");
        }
    }
    // WalkingAnimation()
    
        //animator.Play("Player_walk");
    
}

