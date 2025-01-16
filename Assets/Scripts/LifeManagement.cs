using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManagement : MonoBehaviour
{
    Rigidbody2D Player;
    public int Lives = 3;
    public GameObject Particle;

    AudioSource audioSource;
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
        //Kollar om spelaren nuddar en fiende vilket gör att man förlorar ett liv
        //När man har 0 liv förstörs objeket och spelaren dör
        if (collision.gameObject.tag == ("Enemy"))
        {
            Lives -= 1;
            //audioSource.Play(); //Spelaren dog inte när audio-sourcen var aktiv pga att det inte fanns något ljud att spela
            if (Lives == 0)
            {
                Instantiate(Particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Invoke("LoadGameOver", 2);
            }
        }
        if (collision.gameObject.tag == ("NoKillEnemy"))
        {
            Lives -= 1;

            if (Lives == 0)
            {
                Instantiate(Particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Invoke("LoadGameOver", 2);
            }
        }

        void LoadGameOver()
        {
            SceneManager.LoadScene("Game over");
        }

    }
}
