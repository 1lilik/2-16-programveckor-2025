using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TorchManager : MonoBehaviour
{
    public GameObject[] torches; 
    public Sprite litTorchSprite;
    public Sprite unlitTorchSprite;
    int[] correctSequence; 
    List<int> playerSequence = new List<int>();
    bool puzzleComplete = false;
    public TextMeshProUGUI Feedback;


    private void Start()
    {
        GenerateRandomSequence();
    }

    private void Update()
    {

    }

    private void GenerateRandomSequence()
    {
        int numberOfTorches = torches.Length;
        correctSequence = new int[numberOfTorches];
        Feedback.text = "Light the torches in the right order!";

        // Initialize the sequence with indices
        for (int i = 0; i < numberOfTorches; i++)
        {
            correctSequence[i] = i;
        }
        
        for (int i = numberOfTorches - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = correctSequence[i];
            correctSequence[i] = correctSequence[randomIndex];
            correctSequence[randomIndex] = temp;
        }
        //Prints the correct sequence in the log
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
            Feedback.text = "Wrong order try again!";
            ResetPuzzle();
        }
        else if (playerSequence.Count == correctSequence.Length)
        {
            // Player completed the sequence
            CompletePuzzle();
        }
    }

    async void ResetPuzzle()
    {
        playerSequence.Clear();

        foreach(GameObject torch in torches)
        {
            torch.GetComponent<SpriteRenderer>().sprite = unlitTorchSprite;
        }
        //makes the text "Wrong..." stay for 2000 miliseconds, async void is needed for the await
        await Task.Delay(2000);
        Feedback.text = "Light the torches in the right order!";
    }

    void CompletePuzzle()
    {
        puzzleComplete = true;
        Feedback.text = "Correct order! You won!";
    }
}