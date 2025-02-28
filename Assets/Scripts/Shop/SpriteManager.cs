using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteManager : MonoBehaviour
{
    public Sprite commonBorder, selectedBorder;

    public Sprite emptySlot, filledSlot;

    public void LoadLevel(int index) => SceneManager.LoadScene(index);
}
