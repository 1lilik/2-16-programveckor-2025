using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    float chaseRange;
    float dieRange;
    GameObject player;
    tempmove controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<tempmove>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        float range = Vector3.Distance(player.transform.position, transform.position);
        
        if (range <= dieRange)
        {

            //Temp tags (player loses life)
        }

        else if(range <= chaseRange)
        {
            transform.LookAt(player.transform);
            Vector3 vector3 = transform.TransformDirection(Vector3.forward);
            
        }
    }
}
