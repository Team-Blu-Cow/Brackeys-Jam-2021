using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class BaseShooting : MonoBehaviour
{
    public enum HitType
    {
        Normal,
        Explosive
    }

    public Modifiers m_modifiers;

    public HitType m_hitType;

    // variables used within the class
    private float m_fireCooldown;

    private float m_reloadCooldown;
    
    public GUIStyle style;

    private DebugLabels m_debuglabels;

    public bool m_debug;

    public int m_maxDebugBullets;
    private Queue<GameObject> m_debugBullets = new Queue<GameObject>();

    // Start is called before the first frame update
    public void Start()
    {
        m_reloadCooldown = m_modifiers.m_reloadSpeed;
        m_fireCooldown = m_modifiers.m_fireRate;

        m_debuglabels = FindObjectOfType<DebugLabels>();                
    }

    // Update is called once per frame
    public void Update()
    {
        // Add the time that has passed to the shooting cool downs
        if (m_fireCooldown < m_modifiers.m_fireRate)
            m_fireCooldown += Time.deltaTime;

        if (m_reloadCooldown < m_modifiers.m_reloadSpeed)
            m_reloadCooldown += Time.deltaTime;
    }

    private void LateUpdate()
    {
        // Add labels to debug
        if (m_debuglabels != null)
        {
            m_debuglabels.Add(new List<string>
            {
                "Ammo: " + m_modifiers.m_ammo,
                "Reload: " + m_reloadCooldown,
                "Fire Rate: " + m_fireCooldown
            });
        }
    }

    public virtual bool Shoot()
    {
        // Check if the player is allowed to shoot
        if (m_modifiers.m_ammo == 0 || m_fireCooldown < m_modifiers.m_fireRate || m_reloadCooldown < m_modifiers.m_reloadSpeed)
            return false;

        // Take away shot
        m_fireCooldown = 0;
        m_modifiers.m_ammo--;

        // Check if player has to reload
        if (m_modifiers.m_ammo == 0)
            Reload();

        return true;
    }

    public virtual void OnHit(RaycastHit hit)
    {
        OnHit(hit.transform, hit.point);
    }

    public virtual void OnHit(Collision hit)
    {
        OnHit(hit.transform, hit.GetContact(0).point);
    }

    protected void SpawnDebug(Vector3 point)
    {
        if (m_debug)
        {
            // Spawn a new object to draw the given bullets trail
            GameObject tempBullet = new GameObject("Debug-Bullet");
            m_debugBullets.Enqueue(tempBullet);

            DebugBullet debugBullet = tempBullet.AddComponent<DebugBullet>();

            debugBullet.m_range = m_modifiers.m_range;
            debugBullet.m_shooting = this;
            debugBullet.m_hitType = m_hitType;
            debugBullet.m_hitPos = point;

            tempBullet.transform.position = Camera.main.transform.position;
            if (this is HitscanShooting)
            {
                HitscanShooting hitscan = (HitscanShooting)this;
                tempBullet.transform.forward = Camera.main.transform.forward + hitscan.spread;
            }

            // Clear more than max amount of bullets
            if (m_debugBullets.Count > m_maxDebugBullets)
                Destroy(m_debugBullets.Dequeue());
        }
    }

    public virtual bool OnHit(Transform hit, Vector3 point)
    {
        bool damaged = false;

        switch (m_hitType)
        {
            case HitType.Normal:
                if (hit.CompareTag("Enemy"))
                {
                    Debug.Log(hit.name);
                    damaged = true;
                }
                //Deal damage to hit
                break;

            case HitType.Explosive:
                Collider[] collisions = Physics.OverlapSphere(point, m_modifiers.m_explosiveRadius);

                foreach (Collider collider in collisions)
                    if (collider.CompareTag("Enemy"))
                    {
                        Debug.Log(collider.name);
                        damaged = true;
                    }


                //Deal damage in an area of hit
                break;

            default:
                break;
        }

        SpawnDebug(point);
        return damaged;
    }

    public void Reload()
    {
        if (m_reloadCooldown >= m_modifiers.m_reloadSpeed)
        {
            StartCoroutine(SetAmmo(m_modifiers.m_reloadSpeed));
            // Reset reload cooldown
            m_reloadCooldown = 0;
        }
    }

    // Only refill ammo after given time
    public IEnumerator SetAmmo(float ReloadSpeed)
    {
        yield return new WaitForSeconds(ReloadSpeed);
        m_modifiers.m_ammo = m_modifiers.m_maxAmmo;
    }

    private void OnDrawGizmos()
    {
        // Draw line where player is looking
        Transform camTransform = Camera.main.transform;

        Gizmos.color = Color.red;
        Vector3 direction = camTransform.TransformDirection(Vector3.forward) * m_modifiers.m_range;
        Gizmos.DrawRay(camTransform.position, direction);
    }
}