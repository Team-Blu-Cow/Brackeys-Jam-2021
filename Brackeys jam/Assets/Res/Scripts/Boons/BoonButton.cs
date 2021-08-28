using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoonButton : MonoBehaviour
{
    public BoonPair boons;

    [SerializeField] private PlayerStats stats;
    [HideInInspector] public BoonController controller;

    [SerializeField, HideInInspector] private TextMeshProUGUI blessingText;
    [SerializeField, HideInInspector] private TextMeshProUGUI curseText;
    [SerializeField] public BoonTextWrapper blessing;
    [SerializeField] public BoonTextWrapper curse;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Canvas canvas;

    [SerializeField] private Vector3 selectedScale = new Vector3(1.1f,1.1f,1.1f);
    [SerializeField, Range(0.01f,1f)] private float easeTime = 0.2f;

    [SerializeField] private GameObject explosionPrefab;

    public void Awake()
    {
        OnPointerExit();
    }

    public void SetBoons(BoonPair in_pair)
    {
        boons = in_pair;

        if (blessing == null)
            return;

        blessing.title.text = boons.blessing.displayName;
        blessing.statName.text = boons.blessing.stat_effected.GetName();
        // todo blessing.statLevel.text = 

        PlayerUpgrade.Type upgradeType = stats.upgradeData[(int)boons.blessing.stat_effected].type;

        switch (upgradeType)
        {
            case PlayerUpgrade.Type.FLOAT:
                {
                    stats.upgradeData[(int)boons.blessing.stat_effected].GetValue(out blessing.before);

                    blessing.after = stats.upgradeData[(int)boons.blessing.stat_effected].EvaluateCurve(boons.blessing.value);
                    break;
                }

            case PlayerUpgrade.Type.INT:
                {
                    int temp;
                    stats.upgradeData[(int)boons.blessing.stat_effected].GetValue(out temp);
                    blessing.before = temp;

                    blessing.after = blessing.before + boons.blessing.value;
                    break;
                }
        }

        blessing.SetValues(boons.blessing.value);


        curse.title.text = boons.curse.displayName;
        curse.statName.text = boons.curse.stat_effected.GetName();

        upgradeType = stats.upgradeData[(int)boons.curse.stat_effected].type;

        switch (upgradeType)
        {
            case PlayerUpgrade.Type.FLOAT:
                {
                    stats.upgradeData[(int)boons.curse.stat_effected].GetValue(out curse.before);

                    curse.after = stats.upgradeData[(int)boons.curse.stat_effected].EvaluateCurve(boons.curse.value);
                    break;
                }

            case PlayerUpgrade.Type.INT:
                {
                    int temp;
                    stats.upgradeData[(int)boons.curse.stat_effected].GetValue(out temp);
                    curse.before = temp;

                    curse.after = curse.before + boons.curse.value;
                    break;
                }
        }

        curse.SetValues(boons.curse.value);

        /*blessingText.text = 
            boons.blessing.displayName + 
            "\n" + boons.rarity.GetName() + 
            "\n" + boons.blessing.stat_effected.GetName();*/

        /*curseText.text =
            boons.curse.displayName +
            "\n" + boons.rarity.GetName() +
            "\n" + boons.curse.stat_effected.GetName();*/
    }

    public void OnPointerEnter()
    {
        LeanTween.scale(gameObject, selectedScale, easeTime)
            .setEaseInOutBack();
        if (particles != null)
            particles.Play();


        if (canvas != null)
            canvas.sortingOrder = 2;
    }

    public void OnPointerExit()
    {
        LeanTween.scale(gameObject, Vector3.one, easeTime)
            .setEaseInOutBack();
        if (particles != null)
        {
            particles.Stop();
        }

        if (canvas != null)
            canvas.sortingOrder = 1;
    }

    public void OnPress()
    {
        stats.UpgradeStat(boons.blessing.stat_effected, boons.blessing.value);
        stats.UpgradeStat(boons.curse.stat_effected, boons.curse.value);
        OnPointerExit();
        controller.DisableBoonButtons();

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        //SetBoons(boons);
    }
}
