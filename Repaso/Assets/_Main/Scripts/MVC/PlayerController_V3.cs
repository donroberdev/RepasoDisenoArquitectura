using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController_V3 : MonoBehaviour
{
    PlayerInputReader input;
    PlayerMotor motor;
    PlayerView view;

    void Awake()
    {
        input = GetComponent<PlayerInputReader>();
        motor = GetComponent<PlayerMotor>();
        view = GetComponent<PlayerView>(); // puede estar en el mismo GO
    }

    void FixedUpdate()
    {
        motor.Move(input.Move);
    }

    void Update()
    {
        motor.JumpIfPossible(input.JumpDown);

        if (view != null)
            view.SetAirState(motor.IsGrounded);
    }
}
