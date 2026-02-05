using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public bool JumpDown { get; private set; }

    void Update()
    {
        Move = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        JumpDown = Input.GetKeyDown(KeyCode.Space);
    }
}
