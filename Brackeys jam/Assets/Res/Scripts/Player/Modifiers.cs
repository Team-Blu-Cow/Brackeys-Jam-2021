using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers : MonoBehaviour
{
    [Header("Base Stats")]
    public int base_maxAmmo;

    public float base_reloadSpeed;
    public float base_fireRate;
    public float base_recoil;
    public float base_spread;
    public float base_range;
    public float base_explosiveRadius;
    public int base_bounces;

    [Header("Current values")]
    public int m_ammo;

    public int m_maxAmmo;
    public float m_reloadSpeed;
    public float m_fireRate;
    public float m_recoil;
    public float m_spread;
    public float m_range;
    public float m_explosiveRadius;
    public int m_bounces;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}