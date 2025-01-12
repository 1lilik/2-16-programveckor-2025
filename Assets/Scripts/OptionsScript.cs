using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameManage gameManager;

    void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<GameManage>();
    }

    void OnMouseDown()
    {
        // Detect when the object is clicked
        gameManager.ObjectInteracted(gameObject);
    }
}
