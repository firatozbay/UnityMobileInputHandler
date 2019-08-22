using UnityEngine;
using UnityEngine.EventSystems;

public class DynamicJoystick : Joystick
{
    private static Vector2 _joystickCenter = Vector2.zero;
    private static Vector2 _joyStickPosition = Vector2.zero;

    public override void UpdateJoyStick(Vector2 inputPosition)
    {
        if (!IsActive)
        {
            _joystickCenter = inputPosition;
        }

        _joyStickPosition = inputPosition;
    }

    protected override Vector2 GetInput()
    {
        if (!IsActive)
        {
            return Vector2.zero;
        }

        return Vector2.ClampMagnitude(_joyStickPosition - _joystickCenter, 1f);
    }
}
