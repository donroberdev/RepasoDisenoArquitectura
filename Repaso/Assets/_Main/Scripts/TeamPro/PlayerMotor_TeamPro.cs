using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor_TeamPro : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 6f;

    [Header("Team Hooks (Inspector)")]
    public UnityEvent OnJump;                  // VFX/SFX/Anim/UI
    public UnityEvent OnLand;                  // VFX/SFX/Anim/UI
    public UnityEvent<Vector2> OnMoveChanged;  // Animador (blend tree, etc.)

    // Hooks para programadores (código)
    public event Action Jumped;
    public event Action Landed;

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
        if (move == _move) return;     // evita spam si no cambió
        _move = move;

        OnMoveChanged?.Invoke(_move);
    }

    public void TryJump()
    {
        if (!_isGrounded) return;

        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;

        Jumped?.Invoke();
        OnJump?.Invoke();
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
        if (_isGrounded) return; // no dispares OnLand si ya estaba grounded

        if (collision.contacts.Length > 0)
        {
            _isGrounded = true;

            Landed?.Invoke();
            OnLand?.Invoke();
        }
    }
}
