using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButon:MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadSceneAsync(1);

    }

}
