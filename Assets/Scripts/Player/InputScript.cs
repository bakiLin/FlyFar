using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Zenject;

public class InputScript : MonoBehaviour
{
    [Inject]
    private PlayerPower playerPower;

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

        keyboardInputAction.Keyboard.PowerBar.started += FlyPower;
    }

    private void FlyPower(InputAction.CallbackContext context)
    {
        playerPower.FlyPower();
    }
}
