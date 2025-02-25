using UnityEngine;
using UnityEngine.UI;

public class LevelItemData : MonoBehaviour
{
    public int id;

    public new string name;

    public string description;

    public int lvlMax, lvlCurrent;

    public int[] cost;

    public Image image { get; protected set; }

    public virtual void UpdateLevel() { }
}
