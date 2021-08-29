using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUi : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider ammoBar;

    [SerializeField] private TextMeshProUGUI wave;
    [SerializeField] private TextMeshProUGUI enemiesRemaining;

    [SerializeField] private PlayerController player;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Modifiers gun;

    private bool reloaded = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        wave.text = "Wave: " + spawner.waveNo;
        enemiesRemaining.text = "Enemies Remaining: " + player._enemiesRemaining;

        //healthBar.maxValue = player.maxHealth;
        //healthBar.Value = player.Health;

        if (gun.m_ammo == 0 && reloaded)
        {
            reloaded = false;
            StartCoroutine(ReloadAmmo());
        }

        if (reloaded)
        {
            ammoBar.maxValue = gun.m_maxAmmo;
            ammoBar.value = gun.m_ammo;
        }
    }

    private IEnumerator ReloadAmmo()
    {
        while (ammoBar.value < ammoBar.maxValue)
        {
            ammoBar.value += gun.m_maxAmmo / gun.m_reloadSpeed * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);
        reloaded = true;
    }
}