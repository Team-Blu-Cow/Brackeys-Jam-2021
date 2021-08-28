using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "BrackeysJam/Boon"), System.Serializable]
public class Boon : ScriptableObject
{
    public enum Type
    {
        Blessing,
        Curse,
        Chaos
    }
    public Boon.Type type;
    public Rarity rarity;

    [Header("Display Info")]
    public string displayName = "default boon name";
    public Texture2D icon;

    [Header("Effect")]
    public Stats stat_effected;
    public int value;
}
