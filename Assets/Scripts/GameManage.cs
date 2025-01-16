using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

public class GameManage : MonoBehaviour
{
    public GameObject[] objects; 
    private GameObject correctObject;
    public int lives = 3; 
    public TextMeshProUGUI livesText; 
    public TextMeshProUGUI feedbackText;

    private float feedbackDisplayTime = 2f; 
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    private Coroutine feedbackCoroutine;

    void Start()
    {
        AssignCorrectObject();
        UpdateLivesUI();
    }

    void AssignCorrectObject()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        // Randomly choose one of the 5 objects as the "correct" one
        int randomIndex = Random.Range(0, objects.Length);
        correctObject = objects[randomIndex];
        Debug.Log("Correct Object: " + correctObject.name);
=======
        int randomIndex = Random.Range(0, objects.Length);
        correctObject = objects[randomIndex];
        Debug.Log("Correct Object: " + correctObject.name); 
>>>>>>> Stashed changes
=======
        int randomIndex = Random.Range(0, objects.Length);
        correctObject = objects[randomIndex];
        Debug.Log("Correct Object: " + correctObject.name); 
>>>>>>> Stashed changes
=======
        int randomIndex = Random.Range(0, objects.Length);
        correctObject = objects[randomIndex];
        Debug.Log("Correct Object: " + correctObject.name); 
>>>>>>> Stashed changes
    }

    public void ObjectInteracted(GameObject interactedObject)
    {
        if (interactedObject == correctObject)
        {
            Debug.Log("Correct choice! You survived!");
            ShowFeedback("Correct!", Color.green);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            AssignCorrectObject(); // Assign a new correct object
=======
            AssignCorrectObject();
>>>>>>> Stashed changes
=======
            AssignCorrectObject();
>>>>>>> Stashed changes
=======
            AssignCorrectObject();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                ShowFeedback("You die!", Color.red);
                // Additional game over logic can go here
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
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
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
