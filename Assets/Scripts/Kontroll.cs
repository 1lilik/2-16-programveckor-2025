using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Kontroll : MonoBehaviour
{
    float MoveSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            RotateAndMove(0);
        }
        if (Input.GetKey(KeyCode.A)|| (Input.GetKey(KeyCode.LeftArrow)))
        {
            RotateAndMove(90);
        }
        if (Input.GetKey(KeyCode.S)|| (Input.GetKey(KeyCode.DownArrow)))
        {
            RotateAndMove(180);
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            RotateAndMove(-90);
        }
    }
    void RotateAndMove(float angle)
    {
       
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position += transform.up * MoveSpeed * Time.deltaTime;
    }
}
