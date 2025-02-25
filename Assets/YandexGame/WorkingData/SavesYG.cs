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
        public int color = 0;
        public int face = 0;

        public List<int> colorUnlocked = new List<int>() {0};
        public List<int> faceUnlocked = new List<int>() {0};
        public List<int> enemyUnlocked = new List<int>() {0, 1};
        public List<int> enemyLevel = new List<int>() {0};
    }
}
