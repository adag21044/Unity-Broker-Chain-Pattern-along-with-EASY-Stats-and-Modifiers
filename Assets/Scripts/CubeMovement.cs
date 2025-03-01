using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody bileşenini al
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.fixedDeltaTime;

        // Rigidbody kullanarak hareketi uygula
        rb.MovePosition(rb.position + move);
    }

}
