using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

public class SpriteManager : MonoBehaviour
{
    [Inject]
    private CoinManager coinManager;

    public Sprite commonBorder, selectedBorder;

    public Sprite emptySlot, filledSlot;

    public void LoadLevel(int index) => SceneManager.LoadScene(index);

    public void RewardedAd() => YandexGame.RewVideoShow(0);

    private void GetReward(int id) => coinManager.GetReward();

    private void OnEnable() => YandexGame.RewardVideoEvent += GetReward;

    private void OnDisable() => YandexGame.RewardVideoEvent -= GetReward;
}
