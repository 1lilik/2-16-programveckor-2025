using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        RoomNumber = Random.Range(0, 6);
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein == true)
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= TimeToFade * Time.deltaTime;
            }
            else
            {
                fadein = false;
            }
        }

        if (fadeout == true)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimeToFade * Time.deltaTime;
            }
            else
            {
                fadeout = false;
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

    async void RoomPicker()
    {
        FadeOut();
        await Task.Delay(2000);
        SceneManager.LoadScene(RoomNames[RoomNumber-1]);
    }

    public void FadeIn()
    {
        fadein = true;
        canvasGroup.alpha = 1;
    }

    public void FadeOut()
    {
        fadeout = true;
        canvasGroup.alpha = 0;
    }
}
