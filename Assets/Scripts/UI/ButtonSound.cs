using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.Instance;

        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => audioManager.Play("click", true));
        }
    }
}
