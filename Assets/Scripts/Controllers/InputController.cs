using UnityEngine;

public class InputController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Check_Keyboard_Input();
    }

    private void Check_Keyboard_Input()
    {
        if (InputTracker.Has_Pressed_Key(KeyCode.W) || InputTracker.Has_Pressed_Key(KeyCode.UpArrow))
        {
            LayerController.Instance.MoveForward();
        }
        else if (InputTracker.Has_Pressed_Key(KeyCode.S) || InputTracker.Has_Pressed_Key(KeyCode.DownArrow))
        {
            LayerController.Instance.MoveBackward();
        }
    }
}
