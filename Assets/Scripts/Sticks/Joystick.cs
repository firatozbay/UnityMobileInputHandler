using UnityEngine;

public abstract class Joystick : Stick
{
    [HideInInspector]
    public bool IsActive = false;

    private int _fingerId;

    protected override void Awake()
    {
        base.Awake();
        _fingerId = -1;
    }

    private void Update()
    {
        if (InputHandler.GetTouch())
        {
#if UNITY_EDITOR
            if (InputHandler.GetTouch())
#elif UNITY_ANDROID|| UNITY_IOS
            if (!IsActive)
                _fingerId = InputHandler.TouchingFinger();
            if (_fingerId != -1 && InputHandler.GetTouch(_fingerId))
#endif
            {
                UpdateJoyStick(InputHandler.GetTouchPosition(_fingerId));
                EnableJoyStick();
            }
            else
            {
                DisableJoyStick();
            }
        }
        else
        {
            DisableJoyStick();
        }
    }

    public abstract void UpdateJoyStick(Vector2 inputPosition);

    private void EnableJoyStick()
    {
        IsActive = true;
    }

    private void DisableJoyStick()
    {
        IsActive = false;
    }
}