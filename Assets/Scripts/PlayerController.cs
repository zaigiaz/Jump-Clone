using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 10f;

    [Header("Double Jump")]
    public int doubleJumpAvailable = 0;

    private Rigidbody rb;
    private bool isGrounded = true;
    private int jumpsRemaining;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
        jumpsRemaining = 1;
    }

    void Update()
    {
        CheckGround();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
    }

    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.down * 0.5f, Vector3.down, out hit, 0.1f))
        {
            if (!isGrounded)
            {
                isGrounded = true;
                jumpsRemaining = 1 + doubleJumpAvailable;
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    void TryJump()
    {
        if (jumpsRemaining > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpsRemaining--;
        }
    }

    public void CollectPowerUp()
    {
        doubleJumpAvailable = 1;
    }

    public void ResetJumps()
    {
        jumpsRemaining = 1;
    }

    public void ResetPowerUp()
    {
        doubleJumpAvailable = 0;
    }
}
