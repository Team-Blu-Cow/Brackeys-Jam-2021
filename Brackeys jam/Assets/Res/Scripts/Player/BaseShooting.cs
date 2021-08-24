using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseShooting : MonoBehaviour
{
    // Variables to edit for skills
    public int m_ammo;

    public int m_maxAmmo;
    public float m_reloadSpeed;
    public float m_fireRate;
    public float m_recoil;
    public float m_spread;
    public float m_range;

    // variables used within the class
    private float m_fireCooldown;

    private float m_reloadCooldown;

    public GUIStyle style;

    private DebugLabels m_debuglabels;

    // Start is called before the first frame update
    public void Start()
    {
        m_reloadCooldown = m_reloadSpeed;
        m_fireCooldown = m_fireRate;

        m_debuglabels = FindObjectOfType<DebugLabels>();
    }

    // Update is called once per frame
    public void Update()
    {
        // Add the time that has passed to the shooting cool downs
        if (m_fireCooldown < m_fireRate)
            m_fireCooldown += Time.deltaTime;

        if (m_reloadCooldown < m_reloadSpeed)
            m_reloadCooldown += Time.deltaTime;
    }

    private void LateUpdate()
    {
        // Add labels to debug
        if (m_debuglabels != null)
        {
            m_debuglabels.Add(new List<string>
            {
                "Ammo: " + m_ammo,
                "Reload: " + m_reloadCooldown,
                "Fire Rate: " + m_fireCooldown
            });
        }
    }

    public virtual bool Shoot()
    {
        // Check if the player is allowed to shoot
        if (m_ammo == 0 || m_fireCooldown < m_fireRate || m_reloadCooldown < m_reloadSpeed)
            return false;

        // Take away shot
        m_fireCooldown = 0;
        m_ammo--;

        // Check if player has to reload
        if (m_ammo == 0)
            Reload();

        return true;
    }

    public void Reload()
    {
        if (m_reloadCooldown >= m_reloadSpeed)
        {
            StartCoroutine(SetAmmo(m_reloadSpeed));
            // Reset reload cooldown
            m_reloadCooldown = 0;
        }
    }

    // Only refill ammo after given time
    public IEnumerator SetAmmo(float ReloadSpeed)
    {
        yield return new WaitForSeconds(ReloadSpeed);
        m_ammo = m_maxAmmo;
    }

    private void OnDrawGizmos()
    {
        // Draw line where player is looking
        Transform camTransform = Camera.main.transform;

        Gizmos.color = Color.red;
        Vector3 direction = camTransform.TransformDirection(Vector3.forward) * m_range;
        Gizmos.DrawRay(camTransform.position, direction);
    }
}