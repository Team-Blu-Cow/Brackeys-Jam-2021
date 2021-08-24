using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Stats : int
{
    move_speed          = 0,
    move_friction       = 1,
    jump_height         = 2,
    gravity             = 3,
    fire_rate           = 4,
    bullet_damage       = 5,
    sticky_bombs        = 6,
    air_jump            = 7,
    hp_leech            = 8,
    max_hp              = 9,
    player_size         = 10,
    enemy_size          = 11,
    projectile_amount   = 12,
    bullet_recoil       = 13,
    vision              = 14,
    drunkness           = 15,
    damage_block        = 16,
    health_regen        = 17,
    clip_size           = 18,
    reload_speed        = 19,
    crit_chance         = 20,
}


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerUpgrade[] upgrades;

    public List<IUpgradeData> upgradeData;

    private void OnValidate()
    {
        upgrades = Resources.LoadAll<PlayerUpgrade>("Upgrades");

        Array.Sort(upgrades);
    }

    private void Start()
    {
        
    }

    public void InitStats()
    {
        upgradeData = new List<IUpgradeData>();

        for(int i = 0; i < upgrades.Length; i++)
        {
            upgradeData.Add(upgrades[i].InitUpgradeData());
        }
    }
}

public interface IUpgradeData
{
    public PlayerUpgrade SO { get; set; }

    public void Increase();
    public void Decrease();
}

public class IntUpgrade : IUpgradeData
{
    public int data;

    public PlayerUpgrade SO { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Decrease()
    {
        throw new System.NotImplementedException();
    }

    public void Increase()
    {
        data++;
    }
}

public class FloatUpgrade : IUpgradeData
{
    public float data;

    public PlayerUpgrade SO { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void Decrease()
    {
        throw new System.NotImplementedException();
    }

    public void Increase()
    {
        throw new System.NotImplementedException();
    }
}
