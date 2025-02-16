using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Kontroll : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public Animator animator;
    SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            Rotate(90);
            transform.position += new Vector3(0,1,0) * MoveSpeed * Time.deltaTime;
            animator.Play("Player_walking");
        }
        else if (Input.GetKey(KeyCode.A)|| (Input.GetKey(KeyCode.LeftArrow)))
        {
            Rotate(180);
            transform.position += new Vector3(-1,0,0) * MoveSpeed * Time.deltaTime;
            spriteRend.flipX = true;
            animator.Play("Player_walking");
        }
        else if (Input.GetKey(KeyCode.S)|| (Input.GetKey(KeyCode.DownArrow)))
        {
            Rotate(-90);
            transform.position += new Vector3(0,-1,0) * MoveSpeed * Time.deltaTime;
            animator.Play("Player_walking");
        }
        else if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            Rotate(0);
            transform.position += new Vector3(1,0,0) * MoveSpeed * Time.deltaTime;
            spriteRend.flipX = false;
            animator.Play("Player_walking");
        }
        else
        {
            animator.Play("Player_idle");
        }
    }
    void Rotate(float angle)
    {
        transform.GetChild(0).rotation = Quaternion.Euler(0, 0, angle); 
    }
   
}
