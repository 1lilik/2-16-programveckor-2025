using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public int lives = 3;

    public Image[] lifeIcons;
    public Sprite heartSprite; 
    public Sprite brokenHeartSprite;
    void Start()
    {
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < lives)
            {
                lifeIcons[i].sprite = heartSprite; // Show heart sprite for remaining lives
            }
            else
            {
                lifeIcons[i].sprite = brokenHeartSprite; // Show broken heart for lost lives
            }
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
