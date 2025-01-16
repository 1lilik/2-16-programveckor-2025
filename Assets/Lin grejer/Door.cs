using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    int RoomNumber;
    public string[] RoomNames;
    
    public CanvasGroup canvasGroup;
    public bool fadein = false;
    public bool fadeout = false;
    

    public float TimeToFade;

    // Start is called before the first frame update
    void Start()
    {
        RoomNumber = Random.Range(0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if (fadeout == true)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= TimeToFade * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RoomPicker();
        }
    }

    void RoomPicker()
    {
        if (RoomNumber == 1)
        {
            FadeOut();
            SceneManager.LoadScene(RoomNames[0]);
        }
        else if (RoomNumber == 2)
        {
            FadeOut();
            SceneManager.LoadScene(RoomNames[1]);
        }
        else if (RoomNumber == 3)
        {
            FadeOut();
            SceneManager.LoadScene(RoomNames[2]);
        }
        else if (RoomNumber == 4)
        {
            FadeOut();
            SceneManager.LoadScene(RoomNames[3]);
        }
        else
        {
            FadeOut();
            SceneManager.LoadScene(RoomNames[4]);
        }
    }

    public void FadeIn()
    {
        fadein = true;
    }

    public void FadeOut()
    {
        fadeout = true;
    }
}
