using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Rarity : int
{
    Common      = 0,
    Rare        = 1,
    Legendary   = 2,
}

public static class RarityExtentions
{
    public static string GetName(this Rarity r)
    {
        return System.Enum.GetName(typeof(Rarity), r);
    }
}


public class BoonController : MonoBehaviour
{
    [SerializeField] private Boon[] commonBlessings;
    [SerializeField] private Boon[] rareBlessings;
    [SerializeField] private Boon[] legendaryBlessings;

    [SerializeField] private Boon[] commonCurses;
    [SerializeField] private Boon[] rareCurses;
    [SerializeField] private Boon[] legendaryCurses;

    [SerializeField] private BoonButton[] buttons;

    private int[] rarityTable =
        {
            60, // Common
            30, // rare
            10 // Legendary
        };

    private int rarityTotal;

    private void OnValidate()
    {
        commonBlessings     = Resources.LoadAll<Boon>("Boons/Blessings/Common");
        rareBlessings       = Resources.LoadAll<Boon>("Boons/Blessings/Rare");
        legendaryBlessings  = Resources.LoadAll<Boon>("Boons/Blessings/Legendary");

        commonCurses        = Resources.LoadAll<Boon>("Boons/Curses/Common");
        rareCurses          = Resources.LoadAll<Boon>("Boons/Curses/Rare");
        legendaryCurses     = Resources.LoadAll<Boon>("Boons/Curses/Legendary");
    }

    public void Start()
    {
        rarityTotal = 0;
        foreach (var n in rarityTable)
            rarityTotal += n;

        SetBoonButtons();
    }

    public Rarity RollRarity()
    {
        int r = Random.Range(0, rarityTotal);

        int i;

        for (i = 0; i < rarityTable.Length; i++)
        {
            if (r < rarityTable[i])
                break;

            r -= rarityTable[i];
        }

        return (Rarity)i;
    }

    public BoonPair RollBoon()
    {
        BoonPair pair = new BoonPair();
        pair.rarity = RollRarity();

        switch (pair.rarity)
        {
            case Rarity.Common:
                {
                    int r = Random.Range(0, commonBlessings.Length);
                    pair.blessing = commonBlessings[r];

                    r = Random.Range(0, commonCurses.Length);
                    pair.curse = commonCurses[r];

                    break;
                }

            case Rarity.Rare:
                {
                    int r = Random.Range(0, rareBlessings.Length);
                    pair.blessing = rareBlessings[r];

                    r = Random.Range(0, rareCurses.Length);
                    pair.curse = rareCurses[r];

                    break;
                }

            case Rarity.Legendary:
                {
                    int r = Random.Range(0, legendaryBlessings.Length);
                    pair.blessing = legendaryBlessings[r];

                    r = Random.Range(0, legendaryCurses.Length);
                    pair.curse = legendaryCurses[r];

                    break;
                }
        }

        return pair;

    }

    public void SetBoonButtons()
    {
        foreach(var b in buttons)
        {
            b.SetBoons(RollBoon());
            b.controller = this;
            b.GetComponent<Button>().enabled = false;
            b.GetComponent<UnityEngine.EventSystems.EventTrigger>().enabled = false;

            b.transform.localScale = new Vector3(1, 0, 1);

            LeanTween.scale(b.gameObject, Vector3.one, 0.5f)
                .setEaseOutBack()
                .setOnComplete(() =>
                {
                    b.GetComponent<Button>().enabled = true;
                    b.GetComponent<UnityEngine.EventSystems.EventTrigger>().enabled = true;
                });
        }
    }

    public void DisableBoonButtons()
    {
        foreach(var b in buttons)
        {
            b.GetComponent<Button>().enabled = false;
            b.GetComponent<UnityEngine.EventSystems.EventTrigger>().enabled = false;

            LeanTween.scale(b.gameObject, new Vector3(1,0, 1), 0.5f)
                .setEaseInBack()
                .setOnComplete(() =>
                {
                    // do stuff later
                });
        }
    }
}

[System.Serializable]
public struct BoonPair
{
    public Rarity rarity;

    public Boon blessing;
    public Boon curse;
}
