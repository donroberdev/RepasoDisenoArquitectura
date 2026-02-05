using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] float speed = 6f;
    [SerializeField] float jumpForce = 6f;

    Rigidbody rb;
    bool isGrounded = true;

    public bool IsGrounded => isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {
        Vector3 vel = rb.linearVelocity;
        vel.x = input.x * speed;
        vel.z = input.y * speed;
        rb.linearVelocity = vel;
    }

    public void JumpIfPossible(bool jumpDown)
    {
        if (!jumpDown || !isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
            isGrounded = true;
    }
}
