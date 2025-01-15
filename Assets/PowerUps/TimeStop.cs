using UnityEngine;

public class TimePowerUp : MonoBehaviour
{
    public float Duration = 7f;
    public float SpeedUnderTimeStop = 5f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) //StogPlayer
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if(player != null)
            {
              
                Destroy(gameObject);

            }
        }
    }
    
   public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private bool canMove = true;
    private float timeStopEndTime;

    private void Update()
    {
        HandleMovement();
        CheckTimeStop();
    }

    private void HandleMovement()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    public void ActivateTimeStop(float duration, float speed)
    {
        canMove = true; 
        moveSpeed = speed;
        Time.timeScale = 0;
        timeStopEndTime = Time.realtimeSinceStartup + duration; 
    }

    private void CheckTimeStop()
    {
        if (Time.timeScale == 0 && Time.realtimeSinceStartup >= timeStopEndTime)
        {
            Time.timeScale = 1; 
           
        }
    }
}

}