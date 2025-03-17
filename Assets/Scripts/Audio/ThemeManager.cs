using UnityEngine;
using Zenject;

public class ThemeManager : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private PlayerSpeed playerSpeed;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void OnEnable()
    {
        inputScript.onStart += () => audioManager.Play("run", true);

        playerSpeed.onStop += () => audioManager.Play("run", false);
        playerSpeed.onStop += () => audioManager.Play("game over", true);
    }

    private void OnDestroy()
    {
        audioManager.Play("run", false);
        audioManager.Play("game over", false);
    }
}
