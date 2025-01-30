using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [Inject]
    private PowerBarArrow powerBarArrow;

    [Inject]
    private PlayerGravity playerGravity;

    [Inject]
    private PlayerSpeed playerSpeed;

    [Inject]
    private EnemySpawner enemySpawner;

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
        playerSpeed.Jump(powerBarValue);
        enemySpawner.StartSpawn();

        keyboardInputAction.Keyboard.PowerBar.started -= StopArrow;
    }
}
