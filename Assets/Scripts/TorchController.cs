using UnityEngine;

public class Torch : MonoBehaviour
{
    public int torchIndex; // Assign a unique index to each torch
    private TorchManager TorchPuzzle;

    private void Start()
    {
        TorchPuzzle = FindObjectOfType<TorchManager>();
    }

    private void OnMouseDown()
    {
        // Change sprite to "lit" state
        GetComponent<SpriteRenderer>().sprite = TorchPuzzle.litTorchSprite;
        // Notify the puzzle manager
        TorchPuzzle.LightTorch(torchIndex);
    }
}
