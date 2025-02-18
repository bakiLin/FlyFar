using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Zenject;

public class InputScript : MonoBehaviour
{
    [Inject]
    private FlyPower flyPower;

    private KeyboardInputAction keyboardInputAction;

    public Action onStart;

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

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
    }

    private void StopArrow(InputAction.CallbackContext context)
    {
        onStart?.Invoke();

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;

        keyboardInputAction.Keyboard.PowerBar.started += ((InputAction.CallbackContext context) => { flyPower.Fly(); });
    }
}
