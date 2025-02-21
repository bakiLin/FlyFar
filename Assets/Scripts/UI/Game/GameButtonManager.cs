using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtonManager : MonoBehaviour
{
    [SerializeField]
    private Button replay, shop;

    private void Awake()
    {
        replay.onClick.AddListener(() => { 
            SceneManager.LoadScene(1); 
        });

        shop.onClick.AddListener(() => {
            SceneManager.LoadScene(0);
        });
    }
}
