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

    private KeyboardInputAction keyboardInputAction;

    public Action onStart;

    [HideInInspector]
    public bool powerOn = false;

    private void Awake()
    {
        keyboardInputAction = new KeyboardInputAction();  
    }

    private void OnEnable()
    {
        keyboardInputAction.Enable();

        keyboardInputAction.Keyboard.PowerBar.started += StopArrow;

        playerSpeed.onStop += keyboardInputAction.Disable;
    }

    private void OnDisable()
    {
        keyboardInputAction.Disable();
    }

    private void StopArrow(InputAction.CallbackContext context)
    {
        onStart?.Invoke();

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;

        if (powerOn) keyboardInputAction.Keyboard.PowerBar.started += ((InputAction.CallbackContext context) => { flyPower.Fly(); });

    }

    public void SwitchFlyPower(bool state)
    {
        if (state) keyboardInputAction.Enable();
        else keyboardInputAction.Disable();
    }
}
