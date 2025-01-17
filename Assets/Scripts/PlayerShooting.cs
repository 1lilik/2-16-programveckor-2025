using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{  
    public GameObject Projectile;
    public bool AllowToShoot;
    public Transform shootpoint;
    float ProjectileSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        AllowToShoot = true;

    }

    // Update is called once per frame
    void Update()
    {
        print("Player shooter update");
        if (Input.GetKeyDown(KeyCode.Mouse1) && AllowToShoot == true || (Input.GetKeyDown(KeyCode.Space) && AllowToShoot == true))
        {
            print("Inne i shooting efter press");
            GameObject projectile = Instantiate(Projectile, shootpoint.position, transform.GetChild(0).rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = transform.GetChild(0).right * ProjectileSpeed;
            AllowToShoot = false;
        }
       
    }

}
