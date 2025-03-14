using UnityEngine;
using Zenject;

public class ThemeManager : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private AudioManager audioManager;

    [Inject]
    private PlayerSpeed playerSpeed;

    [SerializeField]
    private string themeName, gameOver;

    private void OnEnable()
    {
        inputScript.onStart += () => audioManager.Play(themeName);

        playerSpeed.onStop += () => audioManager.Stop(themeName);
        playerSpeed.onStop += () => audioManager.Play(gameOver);
    }
}
