using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public static float HorizontalInput { get; private set; }
    public static float VerticalInput { get; private set; }
    public static Vector2 MoveInput { get; private set; }
    public static bool MovementPressed { get; private set; }
    public static bool DodgePressed { get; private set; }
    public static bool SprintPressed { get; private set; }
    public static bool MovementAbilityPressed { get; private set; }

    private void Update()
    {
        //change this to new unity input handler for flexibility
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        MoveInput = new(HorizontalInput, VerticalInput);
        MoveInput.Normalize();
        DodgePressed = Input.GetButtonDown("Jump");
        SprintPressed = Input.GetKey(KeyCode.LeftShift);
        MovementAbilityPressed = Input.GetKeyDown(KeyCode.Q);
        MovementPressed = (HorizontalInput != 0 || VerticalInput != 0) ? true : false;

    }

}
