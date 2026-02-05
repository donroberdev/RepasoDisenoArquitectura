using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController_V1 : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 6f;

    Rigidbody rb;
    Renderer rend;
    Color originalColor;

    bool isGrounded = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void Update()
    {
        // MOVIMIENTO (mezclado)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0f, v).normalized;

        Vector3 vel = rb.linearVelocity;
        vel.x = dir.x * speed;
        vel.z = dir.z * speed;
        rb.linearVelocity = vel;

        // SALTO (mezclado)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            // VISTA (mezclado)
            rend.material.color = Color.yellow;
        }

        // VISTA (mezclado)
        if (isGrounded)
            rend.material.color = originalColor;
    }

    void OnCollisionEnter(Collision collision)
    {
        // “Suelo” por simplicidad (vale para demo)
        if (collision.contacts.Length > 0)
            isGrounded = true;
    }
}
