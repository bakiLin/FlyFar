using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [Inject]
    private GameManage gameManage;

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
        gameManage.StartGame();

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
    }
}
