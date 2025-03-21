using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class FlyPower : MonoBehaviour
{
    [Inject]
    private InputScript inputScript;

    [Inject]
    private TextManager textManager;

    [Inject]
    private PlayerGravity playerGravity;

    [SerializeField]
    private GameObject left, right;

    [SerializeField]
    private GameObject powerUI;

    [SerializeField]
    private int[] powerNumber;

    private AudioManager audioManager;

    public float force, time;

    private int num;

    private void Start()
    {
        int level = YandexGame.savesData.GetPlayerLevel(SceneManager.GetActiveScene().buildIndex)[0];

        if (level > 0)
        {
            inputScript.powerOn = true;
            num = powerNumber[level - 1];
            textManager.SetPower(num);
            powerUI.SetActive(true);
        }

        audioManager = AudioManager.Instance;
    }

    public async void Fly()
    {
        if (num > 0f)
        {
            audioManager.Play("wind", true);

            num--;

            left.SetActive(true);
            right.SetActive(true);

            textManager.SetPower(num);

            await UniTask.Delay((int)(time * 400));

            playerGravity.AddGravity(force);
        }
    }

    public void GetFlyPower()
    {
        num++;
        textManager.SetPower(num);
    }
}
