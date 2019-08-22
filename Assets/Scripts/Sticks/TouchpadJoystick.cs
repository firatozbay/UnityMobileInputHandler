using UnityEngine;
using UnityEngine.EventSystems;

public class TouchpadJoystick : Joystick
{

    private static Vector2 _lastJoystickPosition = Vector2.zero;
    private static Vector2 _joyStickPosition = Vector2.zero;

    public override void UpdateJoyStick(Vector2 inputPosition)
    {
        if (!IsActive)
        {
            _lastJoystickPosition = inputPosition;
            _joyStickPosition = inputPosition;
        }
        else
        {
            _lastJoystickPosition = _joyStickPosition;
            _joyStickPosition = inputPosition;
        }

    }

    protected override Vector2 GetInput()
    {
        if (!IsActive)
            return Vector2.zero;
        return (_joyStickPosition - _lastJoystickPosition)/Screen.height;
    }
}
