using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputEvents_Pro : MonoBehaviour
{
    public event Action<Vector2> MoveChanged;
    public event Action JumpPressed;

    private PlayerControls_Pro _controls;

    private void Awake()
    {
        _controls = new PlayerControls_Pro();

        _controls.Player.Move.performed += ctx => MoveChanged?.Invoke(ctx.ReadValue<Vector2>());
        _controls.Player.Move.canceled  += _   => MoveChanged?.Invoke(Vector2.zero);

        _controls.Player.Jump.performed += _   => JumpPressed?.Invoke();
    }

    private void OnEnable()  => _controls.Enable();
    private void OnDisable() => _controls.Disable();
}
