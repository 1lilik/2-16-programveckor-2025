using UnityEngine;

public class Torch : MonoBehaviour
{
    public int torchIndex; // Assign a unique index to each torch
    private TorchManager TorchPuzzle;
    private AudioSource audioSource;
    //public AudioClip RightoTorch;

    private void Start()
    {
        TorchPuzzle = FindObjectOfType<TorchManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        // Change sprite to "lit" state
        audioSource.Play();
        GetComponent<SpriteRenderer>().sprite = TorchPuzzle.litTorchSprite;
        // Notify the puzzle manager
        TorchPuzzle.LightTorch(torchIndex);
        
    }
}
