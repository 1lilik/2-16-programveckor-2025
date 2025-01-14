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
        if (Input.GetKeyDown(KeyCode.Mouse0) && AllowToShoot == true)
        {
            GameObject projectile = Instantiate(Projectile, shootpoint.position, transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = transform.right * ProjectileSpeed;
            AllowToShoot = false;
            
        }
        
    }
}
