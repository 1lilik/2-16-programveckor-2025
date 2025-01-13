using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameManage gameManager;

    void Start()
    {
       
        gameManager = FindObjectOfType<GameManage>();
    }

    void OnMouseDown()
    {
        gameManager.ObjectInteracted(gameObject);
    }
}
