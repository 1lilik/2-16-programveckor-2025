using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRandomRoom : MonoBehaviour
{
    int RoomNumber;
    public string[] RoomNames;
    FadeInOut Fade;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GetComponent<FadeInOut>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RoomNumber = Random.Range(0, 5);


            if (RoomNumber == 1)
            {
                Fade.FadeOut();
                SceneManager.LoadScene(RoomNames[0]);
            }
            else if (RoomNumber == 2)
            {
                Fade.FadeOut();
                SceneManager.LoadScene(RoomNames[1]);
            }
            else if (RoomNumber == 3)
            {
                Fade.FadeOut();
                SceneManager.LoadScene(RoomNames[2]);
            }
            else if (RoomNumber == 4)
            {
                Fade.FadeOut();
                SceneManager.LoadScene(RoomNames[3]);
            }
            else
            {
                Fade.FadeOut();
                SceneManager.LoadScene(RoomNames[4]);
            }
        }
    }
}
