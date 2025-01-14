using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 


public class GameManage : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject correctObject;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI feedbackText;

    public Image[] lifeIcons; 
    public Sprite heartSprite;  
    public Sprite brokenHeartSprite;  

    private float feedbackDisplayTime = 2f;
    private Coroutine feedbackCoroutine;

    void Start()
    {
        AssignCorrectObject();
        UpdateLivesUI();
    }

    void AssignCorrectObject()
    {
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
            AssignCorrectObject();
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
     
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < lives)
            {
                lifeIcons[i].sprite = heartSprite;
            }
            else
            {
                lifeIcons[i].sprite = brokenHeartSprite;
            }
        }

       
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
