using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения
        public int money = 0;
        public int money2 = 0;
        public int color = 0;
        public int face = 0;
        public int bonusLevel = 0;
        public int currentLevel = 0;

        public bool lvl2Unlocked = false;

        public List<int> colorUnlocked = new List<int>() {0};
        public List<int> faceUnlocked = new List<int>() {0};
        public List<int> enemyUnlocked = new List<int>() {0, 1};

        public int[] enemyLevel = new int[8];
        public int[] playerLevel = new int[5];
        public int[] playerLevel2 = new int[5];

        public int GetMoney(int sceneIndex)
        {
            if (sceneIndex == 1 || sceneIndex == 2) return money;
            else return money2;
        }

        public void SetMoney(int sceneIndex, int value)
        {
            if (sceneIndex == 1 || sceneIndex == 2) money += value;
            else money2 += value;
        }

        public int[] GetPlayerLevel(int sceneIndex)
        {
            if (sceneIndex == 1 || sceneIndex == 2) return playerLevel;
            else return playerLevel2;
        }

        public void SetPlayerLevel(int sceneIndex, int index, int value)
        {
            if (sceneIndex == 1 || sceneIndex == 2) playerLevel[index] = value;
            else playerLevel2[index] = value;
        }
    }
}
