using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Zenject;

public class InputScript : MonoBehaviour
{
    [Inject]
    private FlyPower flyPower;

    [Inject]
    private PlayerSpeed playerSpeed;

    public bool powerOn;

    public Action onStart;

    private KeyboardInputAction keyboardInputAction;

    private void Awake() => keyboardInputAction = new KeyboardInputAction();  

    private void StopArrow(InputAction.CallbackContext context)
    {
        onStart?.Invoke();
        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
        if (powerOn) keyboardInputAction.Keyboard.PowerBar.started += (InputAction.CallbackContext context) => flyPower.Fly();
    }

    public void SwitchPower(bool state)
    {
        if (state) keyboardInputAction.Enable();
        else keyboardInputAction.Disable();
    }

    private void OnEnable()
    {
        keyboardInputAction.Enable();
        keyboardInputAction.Keyboard.PowerBar.started += StopArrow;
        playerSpeed.onStop += keyboardInputAction.Disable;
    }

    private void OnDisable() => keyboardInputAction.Disable();
}
