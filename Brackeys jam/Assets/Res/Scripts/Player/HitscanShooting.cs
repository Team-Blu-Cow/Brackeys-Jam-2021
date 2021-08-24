using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanShooting : BaseShooting
{
    [Header("Hitscan specific")]
    public bool m_debug;

    public int m_maxDebugBullets;
    private Queue<GameObject> m_debugBullets = new Queue<GameObject>();

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;

        // Random spread of the bullet
        Vector3 spread = new Vector3(Random.Range(-m_spread, m_spread), Random.Range(-m_spread, m_spread), 0);

        Transform camTrasform = Camera.main.transform;

        // Check what the bullet hits if anything
        if (Physics.Raycast(camTrasform.position, camTrasform.forward + spread, out RaycastHit hit, m_range))
        {
            Debug.Log(hit.transform.name);
        }

        //if enemy damage

        if (m_debug)
        {
            // Spawn a new object to draw the given bullets trail
            GameObject tempBullet = new GameObject("Debug-Bullet");
            m_debugBullets.Enqueue(tempBullet);

            tempBullet.AddComponent<DebugBullet>();
            tempBullet.GetComponent<DebugBullet>().m_range = m_range;
            tempBullet.transform.position = Camera.main.transform.position;
            tempBullet.transform.forward = Camera.main.transform.forward + spread;

            // Clear more than max amount of bullets
            if (m_debugBullets.Count > m_maxDebugBullets)
                Destroy(m_debugBullets.Dequeue());
        }

        return true;
    }
}