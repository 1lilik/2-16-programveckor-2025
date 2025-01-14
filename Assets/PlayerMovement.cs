using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;


    void Start()
    {

        transform.position = new Vector3(0, 2, 0);


    }



    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
