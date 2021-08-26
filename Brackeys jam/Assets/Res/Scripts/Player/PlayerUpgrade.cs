using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "BrackeysJam/Upgrade"), System.Serializable]
public class PlayerUpgrade : ScriptableObject, IComparable<PlayerUpgrade>
{
    [SerializeField] public string name;

    [SerializeField] public Stats stat_effected;

    [SerializeField] public AnimationCurve increase_curve;

    [SerializeField] public int default_value;

    public enum Type
    {
        FLOAT,
        INT
    }

    [SerializeField] public PlayerUpgrade.Type type;

    public int CompareTo(PlayerUpgrade other)
    {
        if (other == null) return 1;

        int a = (int)stat_effected;

        int b = (int)(other.stat_effected);

        return (a.CompareTo(b));
    }

    public UpgradeData InitUpgradeData()
    {
        switch (stat_effected)
        {
            default:
                switch (type)
                {
                    case PlayerUpgrade.Type.FLOAT:
                        {
                            FloatUpgrade upgrade = new FloatUpgrade();

                            upgrade.SO = this;

                            upgrade.data = 0;

                            upgrade.value = increase_curve.Evaluate(default_value);

                            return upgrade;
                        }

                    case PlayerUpgrade.Type.INT:
                        {
                            IntUpgrade upgrade = new IntUpgrade();

                            upgrade.SO = this;

                            upgrade.data = 0;
                            upgrade.minValue = Mathf.RoundToInt(increase_curve.Evaluate(0f));

                            upgrade.value = default_value;

                            return upgrade;
                        }
                }
                break;
        }

        return null;
    }
}
