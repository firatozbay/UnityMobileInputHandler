using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLogger : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.skin.label.fontSize = 32;
        GUI.Label(new Rect(10,10, 250, 200),"Input: "+InputHandler.Get2DInput());
    }
}
