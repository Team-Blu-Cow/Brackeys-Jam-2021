using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public enum Stats : int
{
    move_speed = 0,
    air_jump = 1,
    jump_height = 2,
    gravity,
    move_friction,
    fire_rate,
    vision
        
}

/*
 *
    fire_rate           = 4,
    bullet_damage       = 5,
    sticky_bombs        = 6,
    hp_leech            = 8,
    max_hp              = 9,
    player_size         = 10,
    enemy_size          = 11,
    projectile_amount   = 12,
    bullet_recoil       = 13,
    damage_block        = 16,
    health_regen        = 17,
    clip_size           = 18,
    reload_speed        = 19,
    crit_chance         = 20,
*/

public class PlayerStats : MonoBehaviour
{
    [SerializeField, HideInInspector] private PlayerUpgrade[] upgrades;
    [SerializeField, HideInInspector] private PlayerController playerController;

    [SerializeField, HideInInspector] private Modifiers modifiers;

    [SerializeField, HideInInspector] private Volume cameraVolume;
    [SerializeField, HideInInspector] private PSX.Fog fogShader;


    [SerializeField] public UpgradeDataList upgradeData;

    private void OnValidate()
    {
        upgrades = Resources.LoadAll<PlayerUpgrade>("Upgrades");
        playerController = GetComponent<PlayerController>();

        modifiers = playerController._gun;

        cameraVolume = Camera.main.GetComponent<Volume>();
        cameraVolume.profile.TryGet<PSX.Fog>(out fogShader);


        Array.Sort(upgrades);
    }

    private void Start()
    {
        cameraVolume = Camera.main.GetComponent<Volume>();
        cameraVolume.profile.TryGet<PSX.Fog>(out fogShader);

        InitStats();
    }

    public void InitStats()
    {
        //upgradeData = new List<UpgradeData>();
        upgradeData.Init();

        for (int i = 0; i < upgrades.Length; i++)
        {
            upgradeData.Add(upgrades[i].InitUpgradeData());
            upgradeData[i].type = upgrades[i].type;
            upgradeData[i].stat = upgrades[i].stat_effected;
        }
    }

    public void UpgradeStat(Stats index, int value) => UpgradeStat((int)index, value);
    public void UpgradeStat(int index, int value)
    {
        if (value < 0)
            upgradeData[index].Decrease();
        else if (value > 0)
            upgradeData[index].Increase();

        ApplyUpdate(index);
    }

    public void ApplyUpdate(int index)
    {
        switch ((Stats)index)
        {
            case Stats.move_speed:
                {
                    float multiplier;
                    upgradeData[index].GetValue(out multiplier);
                    playerController.moveSpeed = playerController.base_MoveSpeed * multiplier;
                    break;
                }

            case Stats.air_jump:
                {
                    int value;
                    upgradeData[index].GetValue(out value);
                    playerController.numberOfAirJumps = value;
                    break;
                }

            case Stats.jump_height:
                {
                    float multiplier;
                    upgradeData[index].GetValue(out multiplier);
                    playerController.jumpSpeed = playerController.base_JumpSpeed * multiplier;
                    break;
                }

            case Stats.gravity:
                {
                    float multiplier;
                    upgradeData[index].GetValue(out multiplier);
                    playerController.gravity = playerController.base_Gravity * multiplier;
                    break;
                }

            case Stats.move_friction:
                {
                    float multiplier;
                    upgradeData[index].GetValue(out multiplier);
                    playerController.friction = playerController.base_Friction * multiplier;
                    break;
                }


            case Stats.fire_rate:
                {
                    float multiplier;
                    upgradeData[index].GetValue(out multiplier);
                    modifiers.m_fireRate = modifiers.base_fireRate * multiplier;
                    break;
                }

            case Stats.vision:
                {
                    float fogDistance;
                    upgradeData[index].GetValue(out fogDistance);
                    fogShader.fogDistance.SetValue(new FloatParameter(fogDistance));

                    break;
                }

            default:
                {
                }
                break;
        }
    }
}

[System.Serializable]
public class UpgradeDataList
{
    [SerializeField] public List<UpgradeData> data;

    public void Init() => data = new List<UpgradeData>();

    public void Add(UpgradeData input) => data.Add(input);

    public UpgradeData this[int i]
    {
        get { return data[i]; }
        set { data[i] = value; }
    }
}

[System.Serializable]
public class UpgradeData
{
    [SerializeField] public PlayerUpgrade SO;

    [SerializeField] public PlayerUpgrade.Type type;
    [SerializeField] public Stats stat;

    [SerializeField] public int data;

    public void GetValue(out int int_value) => GetValue(out int_value, out _);

    public void GetValue(out float float_value) => GetValue(out _, out float_value);

    public virtual void GetValue(out int int_value, out float float_value)
    {
        int_value = 1;
        float_value = 1f;
    }

    public virtual void Increase()
    {
    }

    public virtual void Decrease()
    {
    }
}

[System.Serializable]
public class IntUpgrade : UpgradeData
{
    [SerializeField] public int value;
    [SerializeField] public int minValue;

    public override void GetValue(out int int_value, out float float_value)
    {
        int_value = value;
        float_value = 0f;
    }

    public override void Decrease()
    {
        data--;
        if (data + SO.default_value >= SO.default_value)
            value--;
    }

    public override void Increase()
    {
        data++;
        if (data + SO.default_value > SO.default_value)
            value++;
    }
}

[System.Serializable]
public class FloatUpgrade : UpgradeData
{
    [SerializeField] public float value;

    public override void GetValue(out int int_value, out float float_value)
    {
        int_value = 0;
        float_value = value;
    }

    public override void Decrease()
    {
        data--;

        value = SO.increase_curve.Evaluate(data);
    }

    public override void Increase()
    {
        data++;

        value = SO.increase_curve.Evaluate(data);
    }
}