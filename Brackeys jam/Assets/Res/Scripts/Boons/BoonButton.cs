using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoonButton : MonoBehaviour
{
    public BoonPair boons;

    [SerializeField, HideInInspector] private TextMeshProUGUI blessingText;
    [SerializeField, HideInInspector] private TextMeshProUGUI curseText;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Canvas canvas;

    [SerializeField] private Vector3 selectedScale = new Vector3(1.1f,1.1f,1.1f);
    [SerializeField, Range(0.01f,1f)] private float easeTime = 0.2f;

    public void Awake()
    {
        OnPointerExit();
    }

    public void SetBoons(BoonPair in_pair)
    {
        boons = in_pair;

        blessingText.text = 
            boons.blessing.displayName + 
            "\n" + boons.rarity.GetName() + 
            "\n" + boons.blessing.stat_effected.GetName();

        curseText.text =
            boons.curse.displayName +
            "\n" + boons.rarity.GetName() +
            "\n" + boons.curse.stat_effected.GetName();
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


}
