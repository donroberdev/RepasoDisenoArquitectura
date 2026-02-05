using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController_V2 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 6f;

    [Header("Jump")]
    [SerializeField] float jumpForce = 6f;

    Rigidbody rb;
    Renderer rend;
    Color originalColor;

    Vector2 moveInput;
    bool jumpPressed;
    bool isGrounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void Update()
    {
        ReadInput();
        HandleJumpRequest();
        UpdateView();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void ReadInput()
    {
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        jumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

    void ApplyMovement()
    {
        Vector3 vel = rb.linearVelocity;
        vel.x = moveInput.x * speed;
        vel.z = moveInput.y * speed;
        rb.linearVelocity = vel;
    }

    void HandleJumpRequest()
    {
        if (!jumpPressed || !isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void UpdateView()
    {
        // Vista por ahora: color en el aire
        rend.material.color = isGrounded ? originalColor : Color.yellow;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
            isGrounded = true;
    }
}
