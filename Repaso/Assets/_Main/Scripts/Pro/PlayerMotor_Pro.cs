using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor_Pro : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 6f;

    private Rigidbody _rb;
    private Vector2 _move;
    private bool _isGrounded = true;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetMove(Vector2 move)
    {
        _move = move;
    }

    public void TryJump()
    {
        if (!_isGrounded) return;

        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }

    private void FixedUpdate()
    {
        Vector3 vel = _rb.linearVelocity;
        vel.x = _move.x * speed;
        vel.z = _move.y * speed;
        _rb.linearVelocity = vel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
            _isGrounded = true;
    }
}
