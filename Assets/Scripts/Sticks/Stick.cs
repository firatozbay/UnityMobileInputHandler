using UnityEngine;

public abstract class Stick : MonoBehaviour
{
    protected virtual void Awake()
    {
        InputHandler.AddStick(this);
    }

    protected abstract Vector2 GetInput();

    public float GetHorizontal()
    {
        return GetInput().x;
    }

    public float GetVertical()
    {
        return GetInput().y;
    }
}
