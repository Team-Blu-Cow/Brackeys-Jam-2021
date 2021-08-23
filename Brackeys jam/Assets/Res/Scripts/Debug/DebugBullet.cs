using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBullet : MonoBehaviour
{
    private bool m_hit = false;
    private Vector3 m_hitPos;
    public float m_range;

    // Start is called before the first frame update
    private void Start()
    {
        // Check to see if the bullet would have hit anything (could be improved and passed in from the first ray cast)
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, m_range))
        {
            m_hit = true;
            m_hitPos = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        // Set to max range
        float dist = m_range;
        Gizmos.color = new Color(0, 0, 1, 0.5f);

        // get the shorter distance and draw a sphere
        if (m_hit)
        {
            dist = Vector3.Distance(transform.position, m_hitPos);
            Gizmos.DrawSphere(m_hitPos, 0.2f);
        }

        Gizmos.color = Color.red;

        // Draw line from start in shot direction
        Vector3 direction = transform.TransformDirection(Vector3.forward) * dist;
        Gizmos.DrawRay(transform.position, direction);
    }
}