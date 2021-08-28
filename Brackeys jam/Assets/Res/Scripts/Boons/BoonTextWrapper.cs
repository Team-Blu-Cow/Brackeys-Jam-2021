using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoonTextWrapper : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI title;
    [SerializeField] public TextMeshProUGUI statName;
    [SerializeField] public TextMeshProUGUI statLevel;
    [SerializeField] public TextMeshProUGUI beforeStat;
    [SerializeField] public TextMeshProUGUI afterStat;

    [SerializeField] private Color[] colours;

    public int level;
    public float before;
    public float after;

    public void SetValues(int val)
    {
        beforeStat.text = before.ToString();
        afterStat.text = after.ToString();

        if(val >= 0)
        {
            statLevel.text = "+" + val.ToString();
            afterStat.color = colours[1];
        }
        else
        {
            statLevel.text = "-" + Mathf.Abs(val).ToString();
            afterStat.color = colours[0];
        }

        /*
        if (before > after)
        {
            afterStat.color = colours[0];
        }
        else if(before < after)
        {
            afterStat.color = colours[1];
        }
        else
        {
            afterStat.color = colours[2];
        }*/
    }
}
