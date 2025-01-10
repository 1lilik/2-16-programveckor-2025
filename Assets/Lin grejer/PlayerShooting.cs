using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{  
    public GameObject Projectile;
    public bool AllowToShoot;
    
    

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
            Instantiate(Projectile, transform.position, Quaternion.identity);
            AllowToShoot = false;
            
        }
        
    }
    
}
