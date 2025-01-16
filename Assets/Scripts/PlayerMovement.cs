using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;


    void Start()
    {
<<<<<<< Updated upstream:Assets/Scripts/PlayerMovement.cs

        transform.position = new Vector3(0, 2, 0);

=======
        transform.position = new Vector3(0, 2, 0);
>>>>>>> Stashed changes:Assets/PlayerMovement.cs

    }



    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
