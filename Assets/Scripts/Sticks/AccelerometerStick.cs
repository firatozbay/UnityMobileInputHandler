using UnityEngine;

public class AccelerometerStick : Stick
{
    [SerializeField, Range(0,1)]
    private float _deadzone = 0.1f;

    protected override Vector2 GetInput()
    {
        var x = Mathf.Abs(Input.acceleration.x) < _deadzone ? 0 : Input.acceleration.x;
        var y = Mathf.Abs(Input.acceleration.y) < _deadzone ? 0 : Input.acceleration.y;
        return new Vector2(x, y);
    }
}
