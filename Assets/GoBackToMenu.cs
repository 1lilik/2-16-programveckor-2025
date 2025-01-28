using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
    bool AllowToGoBack;
    
    // Start is called before the first frame update
    void Start()
    {
        AllowToGoBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllowToGoBack == true)
        {
            Invoke("GoBackToMain", 3);
        }
    }

    void GoBackToMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
