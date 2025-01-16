using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAnimation : MonoBehaviour
{
    public Sprite Fire;
    public Sprite NonFire;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShooting playerShooting = FindObjectOfType<PlayerShooting>();

        if (playerShooting.AllowToShoot == true)
        {
            spriteRenderer.sprite = NonFire;
        }
        else
        {
            spriteRenderer.sprite = Fire;
        }
    }
}
