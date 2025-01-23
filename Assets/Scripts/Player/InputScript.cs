using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [Inject]
    private PowerBarArrow powerBarArrow;

    [Inject]
    private PlayerGravity playerGravity;

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
        float powerBarValue = powerBarArrow.StopArrow();
        playerGravity.Jump(powerBarValue);

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
    }
}
