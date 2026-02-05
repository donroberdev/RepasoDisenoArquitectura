using UnityEngine;

[RequireComponent(typeof(PlayerInputEvents_Pro))]
[RequireComponent(typeof(PlayerMotor_Pro))]
public class PlayerController_Pro : MonoBehaviour
{
    private PlayerInputEvents_Pro _input;
    private PlayerMotor_Pro _motor;
    private PlayerView_Pro _view;

    private void Awake()
    {
        _input = GetComponent<PlayerInputEvents_Pro>();
        _motor = GetComponent<PlayerMotor_Pro>();
        _view  = GetComponent<PlayerView_Pro>();
    }

    private void OnEnable()
    {
        _input.MoveChanged += OnMoveChanged;
        _input.JumpPressed += OnJumpPressed;
    }

    private void OnDisable()
    {
        _input.MoveChanged -= OnMoveChanged;
        _input.JumpPressed -= OnJumpPressed;
    }

    private void Update()
    {
        if (_view != null)
            _view.SetAirState(_motor.IsGrounded);
    }

    private void OnMoveChanged(Vector2 move)
    {
        _motor.SetMove(move);
    }

    private void OnJumpPressed()
    {
        _motor.TryJump();
    }
}
