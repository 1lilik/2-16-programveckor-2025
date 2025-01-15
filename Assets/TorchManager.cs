using System.Collections.Generic;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    public GameObject[] torches; 
    public Sprite litTorchSprite;
    public Sprite unlitTorchSprite;

    int[] correctSequence; 
    List<int> playerSequence = new List<int>();
    bool puzzleComplete = false;

    private void Start()
    {
        GenerateRandomSequence();
    }

    private void GenerateRandomSequence()
    {
        int numberOfTorches = torches.Length;
        correctSequence = new int[numberOfTorches];

        // Initialize the sequence with indices
        for (int i = 0; i < numberOfTorches; i++)
        {
            correctSequence[i] = i;
        }

        // Shuffle the sequence using Fisher-Yates
        for (int i = numberOfTorches - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = correctSequence[i];
            correctSequence[i] = correctSequence[randomIndex];
            correctSequence[randomIndex] = temp;
        }

        Debug.Log("Randomized sequence: " + string.Join(", ", correctSequence));
    }

    public void LightTorch(int torchIndex)
    {
        if (puzzleComplete) return;

        // Add the torch index to the player's sequence
        playerSequence.Add(torchIndex);

        // Check the current sequence
        if (playerSequence[playerSequence.Count - 1] != correctSequence[playerSequence.Count - 1])
        {
            // Player lit the wrong torch
            ResetPuzzle();
        }
        else if (playerSequence.Count == correctSequence.Length)
        {
            // Player completed the sequence
            CompletePuzzle();
        }
    }

    private void ResetPuzzle()
    {
        Debug.Log("Incorrect sequence! Resetting...");
        playerSequence.Clear();

        // Reset all torches to the unlit state
        foreach (GameObject torch in torches)
        {
            torch.GetComponent<SpriteRenderer>().sprite = unlitTorchSprite;
        }
    }

    private void CompletePuzzle()
    {
        puzzleComplete = true;
        Debug.Log("Puzzle solved!");

        // You can trigger additional effects here, like opening a door or playing a sound.
    }
}
