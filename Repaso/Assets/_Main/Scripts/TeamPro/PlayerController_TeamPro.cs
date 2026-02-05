using UnityEngine;

[RequireComponent(typeof(PlayerInputEvents_TeamPro))]
[RequireComponent(typeof(PlayerMotor_TeamPro))]
public class PlayerController_TeamPro : MonoBehaviour
{
    private PlayerInputEvents_TeamPro _input;
    private PlayerMotor_TeamPro _motor;

    private void Awake()
    {
        _input = GetComponent<PlayerInputEvents_TeamPro>();
        _motor = GetComponent<PlayerMotor_TeamPro>();
    }

    private void OnEnable()
    {
        _input.MoveChanged += _motor.SetMove;
        _input.JumpPressed += _motor.TryJump;
    }

    private void OnDisable()
    {
        _input.MoveChanged -= _motor.SetMove;
        _input.JumpPressed -= _motor.TryJump;
    }
}
