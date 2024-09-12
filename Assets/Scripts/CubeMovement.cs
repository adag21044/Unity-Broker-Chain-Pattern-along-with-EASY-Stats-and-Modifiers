using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı

    void Update()
    {
        // Input ile WASD tuşlarını okuyoruz
        float moveX = Input.GetAxis("Horizontal"); // A ve D tuşları (X ekseni)
        float moveZ = Input.GetAxis("Vertical");   // W ve S tuşları (Z ekseni)

        // Hareket vektörü oluşturuyoruz
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;

        // Küpün pozisyonunu güncelliyoruz
        transform.Translate(move);
    }
}
