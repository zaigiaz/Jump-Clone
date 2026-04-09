using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 15f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x, bounceForce, 0);
            }
            
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ResetJumps();
            }
        }
    }
}