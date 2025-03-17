using UnityEngine;

public class ShopTheme : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play("shop", true);
    }

    private void OnDestroy()
    {
        AudioManager.Instance.Play("shop", false);
    }
}
