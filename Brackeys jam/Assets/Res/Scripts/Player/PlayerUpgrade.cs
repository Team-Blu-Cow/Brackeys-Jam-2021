using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "BrackeysJam/Upgrade")]
public class PlayerUpgrade : ScriptableObject, IComparable<PlayerUpgrade>
{
    public string name;
    
    public Stats stat_effected;

    public AnimationCurve increase_curve;

    public float default_value;

    public enum Type
    {
        FLOAT,
        INT
    }

    public PlayerUpgrade.Type type;

    public int CompareTo(PlayerUpgrade other)
    {
        if (other == null) return 1;

        int a = (int)stat_effected;

        int b = (int)(other.stat_effected);

        return (a.CompareTo(b));
    }

    public IUpgradeData InitUpgradeData()
    {
        switch (type)
        {
            case PlayerUpgrade.Type.FLOAT:
                {
                    FloatUpgrade upgrade = new FloatUpgrade();

                    upgrade.SO = this;

                    return upgrade;
                }

            case PlayerUpgrade.Type.INT:
                {
                    IntUpgrade upgrade = new IntUpgrade();

                    upgrade.SO = this;

                    return upgrade;
                }
        }

        return null;
    }
}
