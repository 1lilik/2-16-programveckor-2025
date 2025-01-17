using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public GameObject[] objects; // Assign all 5 objects in the Inspector
    private GameObject correctObject;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI feedbackText;

    public Image[] lifeIcons; // Drag the 3 UI Image objects representing lives
    public Sprite heartSprite; // Assign your "heart" sprite here
    public Sprite brokenHeartSprite; // Assign your "broken heart" sprite here
    

    private float feedbackDisplayTime = 2f;
    private Coroutine feedbackCoroutine;
    public GameObject Door;

    void Start()
    {
        AssignCorrectObject();
        UpdateLivesUI();
        Invoke("DeactivateDoor", 1);
    }

    void AssignCorrectObject()
    {

        // Randomly choose one of the 5 objects as the "correct" one
        int randomIndex = Random.Range(0, objects.Length);
        correctObject = objects[randomIndex];
        Debug.Log("Correct Object: " + correctObject.name);
    }

    public void ObjectInteracted(GameObject interactedObject)
    {
        if (interactedObject == correctObject)
        {
            Debug.Log("Correct choice! You survived!");
            ShowFeedback("Correct!", Color.green);

            AssignCorrectObject(); // Assign a new correct object
            Door.SetActive(true);

        }
        else
        {
            Debug.Log("Wrong choice! You lost a life!");
            lives--;
            ShowFeedback("Incorrect!", Color.red);
            UpdateLivesUI();

            if (lives <= 0)
            {
                Debug.Log("Game Over!");

                ShowFeedback("You die!", Color.red);
                // Additional game over logic can go here

            }
        }
    }

    void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;

        if (feedbackCoroutine != null)
        {
            StopCoroutine(feedbackCoroutine);
        }
        feedbackCoroutine = StartCoroutine(HideFeedbackAfterDelay());
    }

    System.Collections.IEnumerator HideFeedbackAfterDelay()
    {
        yield return new WaitForSeconds(feedbackDisplayTime);
        feedbackText.text = "";
    }

    void UpdateLivesUI()
    {

        // Update the life icons
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < lives)
            {
                lifeIcons[i].sprite = heartSprite; // Show heart sprite for remaining lives
            }
            else
            {
                lifeIcons[i].sprite = brokenHeartSprite; // Show broken heart for lost lives
            }
        }

        // Optional: Update the text-based lives display

        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
    void DeactivateDoor()
    {
        Door.SetActive(false);
    }
}
