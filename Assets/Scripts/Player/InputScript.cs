using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Zenject;

public class InputScript : MonoBehaviour
{
    [Inject]
    private FlyPower playerPower;

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
        playerPower.Fly();
    }

    public void SwitchFly(bool state)
    {
        if (state) keyboardInputAction.Keyboard.PowerBar.started += FlyPower;
        else keyboardInputAction.Keyboard.PowerBar.started -= FlyPower;
    }
}
