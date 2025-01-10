using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManagement : MonoBehaviour
{
    Rigidbody2D Player;
    int Lives = 3;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Lives -= 1;
            audioSource.Play();
            if (Lives == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
