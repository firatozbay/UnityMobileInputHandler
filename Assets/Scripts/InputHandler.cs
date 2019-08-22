using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour
{
    private static List<Stick> _sticks;

    private static bool _previousTouch;

    #region UnityMessages
    private void Awake()
    {
        _sticks = new List<Stick>();
    }

    private void Update()
    {

        //if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        //{ 
        //    _fingerId = Input.GetTouch(0).fingerId;
        //}
        //else if (Input.touchCount == 2)
        //{
        //    if (EventSystem.current.IsPointerOverGameObject(_fingerId))
        //    {
        //        _fingerId = _fingerId == Input.GetTouch(0).fingerId ?
        //            Input.GetTouch(1).fingerId : Input.GetTouch(0).fingerId;
        //    }
        //}

    }

    private void LateUpdate()
    {
        _previousTouch = GetTouch();
    }
    #endregion

    public static float GetHorizontal()
    {
        var total = Input.GetAxis("Horizontal");
        foreach (var stick in _sticks)
            total += stick.GetHorizontal();
        return Mathf.Clamp(total, -1, 1);
    }

    public static float GetVertical()
    {
        var total = Input.GetAxis("Vertical");
        foreach (var stick in _sticks)
            total += stick.GetVertical();
        return Mathf.Clamp(total, -1, 1);
    }

    public static Vector3 Get3DInput()
    {
        return new Vector3(GetHorizontal(), 0, GetVertical());
    }

    public static Vector2 Get2DInput()
    {
        return new Vector2(GetHorizontal(), GetVertical());
    }

    public static void AddStick(Stick joystick)
    {
        _sticks.Add(joystick);
    }

    public static bool GetTouch()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.GetMouseButton(0);
#elif UNITY_ANDROID || UNITY_IOS
        return Input.touchCount > 0;
#endif
    }

    public static bool GetTouch(int fingerId)
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.GetMouseButton(0);
#elif UNITY_ANDROID || UNITY_IOS
        return (Touch(fingerId).phase == TouchPhase.Began || Touch(fingerId).phase == TouchPhase.Stationary || Touch(fingerId).phase == TouchPhase.Moved);
#endif
    }

    public static bool GetTouchDown()
    {
        return !_previousTouch && GetTouch();
    }

    public static bool GetTouchUp()
    {
        return _previousTouch && !GetTouch();
    }

    public static Touch Touch(int fingerId)
    {
        foreach (var touch in Input.touches)
        {
            if (touch.fingerId == fingerId)
                return touch;
        }
        return Input.GetTouch(0);
    }
    
    public static Vector2 GetTouchPosition(int fingerId)
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        return Input.mousePosition;
#elif UNITY_ANDROID || UNITY_IOS
        return Touch(fingerId).position;
#endif
    }

    public static int TouchingFinger()
    {
#if UNITY_ANDROID || UNITY_IOS
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return touch.fingerId;
            }
        }
#endif
        return -1;
    }

}
