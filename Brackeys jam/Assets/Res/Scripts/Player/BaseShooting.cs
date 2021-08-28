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

    [SerializeField, HideInInspector] public Modifiers m_modifiers;

    public HitType m_hitType;

    // variables used within the class
    private float m_fireCooldown;

    private float m_reloadCooldown;

    private DebugLabels m_debuglabels;

    private bool m_debug;

    public bool DebugBool
    {
        get { return m_debug; }
        set
        {
            if (value == m_debug)
                return;

            m_debug = value;
            foreach (GameObject gameObject in m_debugBullets)
            {
                gameObject.SetActive(m_debug);
            }
        }
    }

    public int m_maxDebugBullets;
    private Queue<GameObject> m_debugBullets = new Queue<GameObject>();

    [SerializeField, HideInInspector] private PlayerControls _input;

    private void OnValidate()
    {
        _input = new PlayerControls();
        m_modifiers = GetComponentInParent<Modifiers>();
    }

    // Start is called before the first frame update
    public void Start()
    {
        m_reloadCooldown = m_modifiers.m_reloadSpeed;
        m_fireCooldown = m_modifiers.m_fireRate;

        m_debuglabels = FindObjectOfType<DebugLabels>();

        _input.Player.Reload.performed += ctx => { DebugBool = !DebugBool; };
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

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
        if (m_debuglabels != null && m_modifiers != null)
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

        blu.App.GetModule<blu.AudioModule>().PlayAudioEvent("event:/SFX/Player/Shoot/Shooting");
        return true;
    }

    protected void SpawnDebug(Vector3 point, bool hit)
    {
        // Spawn a new object to draw the given bullets trail
        GameObject tempBullet = new GameObject("Debug-Bullet");
        m_debugBullets.Enqueue(tempBullet);

        DebugBullet debugBullet = tempBullet.AddComponent<DebugBullet>();

        debugBullet.m_range = m_modifiers.m_range;
        debugBullet.m_shooting = this;
        debugBullet.m_hitType = m_hitType;
        debugBullet.m_hitPos = new List<Vector3> { point };
        debugBullet.m_hit = hit;

        tempBullet.transform.position = Camera.main.transform.position;
        if (this is HitscanShooting)
        {
            HitscanShooting hitscan = (HitscanShooting)this;
            debugBullet.m_hitPos = hitscan.points;
        }

        debugBullet.Setup();

        // Clear more than max amount of bullets
        if (m_debugBullets.Count > m_maxDebugBullets)
            Destroy(m_debugBullets.Dequeue());

        if (!m_debug)
            tempBullet.SetActive(false);
    }

    public virtual void OnHit(RaycastHit hit)
    {
        OnHit(hit.transform, hit.point);
    }

    public virtual void OnHit(Collision hit)
    {
        OnHit(hit.transform, hit.GetContact(0).point);
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
                    hit.GetComponent<BasicPathfinder>().Hit();
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

        SpawnDebug(point, damaged);
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