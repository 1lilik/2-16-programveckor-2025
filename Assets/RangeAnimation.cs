using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAnimation : MonoBehaviour
{
    public Sprite Fire;
    public Sprite NonFire;
    SpriteRenderer spriteRenderer;
    bool ActiveFire;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spriteRenderer.sprite = Fire;
            ActiveFire = true;
        }
        else if (ActiveFire = true)
        {
            Invoke("ChangeBackSprite", 1f);
        }
        
    }

    void ChangeBackSprite()
    {
        ActiveFire = false;
        spriteRenderer.sprite = NonFire;
    }
}
