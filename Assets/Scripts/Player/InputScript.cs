using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputScript : MonoBehaviour
{
    public Action onStart;

    private KeyboardInputAction keyboardInputAction;

    private void Awake()
    {
        keyboardInputAction = new KeyboardInputAction();  
    }

    private void OnEnable()
    {
        keyboardInputAction.Enable();

        keyboardInputAction.Keyboard.PowerBar.started += StopArrow;
    }

    private void OnDisable()
    {
        keyboardInputAction.Disable();
    }

    private void StopArrow(InputAction.CallbackContext context)
    {
        onStart?.Invoke();

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
    }
}
