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

    private MobileInputAction mobileInputAction;

    private void Awake()
    {
        keyboardInputAction = new KeyboardInputAction();
        mobileInputAction = new MobileInputAction();
    }

    private void OnEnable()
    {
        keyboardInputAction.Enable();
        keyboardInputAction.Keyboard.PowerBar.started += StopArrow;
        playerSpeed.onStop += keyboardInputAction.Disable;

        mobileInputAction.Enable();
        mobileInputAction.Touch.Press.started += StopArrow;
        playerSpeed.onStop += mobileInputAction.Disable;
    }

    private void OnDisable()
    {
        keyboardInputAction.Disable();
        mobileInputAction.Disable();
    }

    private void StopArrow(InputAction.CallbackContext context)
    {
        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
        mobileInputAction.Touch.Press.started -= StopArrow;

        if (powerOn)
        {
            keyboardInputAction.Keyboard.PowerBar.started += (InputAction.CallbackContext context) => flyPower.Fly();
            mobileInputAction.Touch.Press.started += (InputAction.CallbackContext context) => flyPower.Fly();
        }

        onStart?.Invoke();
    }

    public void SwitchPower(bool state)
    {
        if (state)
        {
            keyboardInputAction.Enable();
            mobileInputAction.Enable();
        }
        else
        {
            keyboardInputAction.Disable();
            mobileInputAction.Disable();
        }
    }
}
