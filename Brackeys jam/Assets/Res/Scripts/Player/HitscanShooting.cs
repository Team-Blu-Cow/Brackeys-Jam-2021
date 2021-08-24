using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanShooting : BaseShooting
{
    [HideInInspector]
    public Vector3 spread;

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;

        // Random spread of the bullet
        spread = new Vector3(Random.Range(-m_spread, m_spread), Random.Range(-m_spread, m_spread), 0);

        Transform camTrasform = Camera.main.transform;

        // Check what the bullet hits if anything
        if (Physics.Raycast(camTrasform.position, camTrasform.forward + spread, out RaycastHit hit, m_range))
        {
            OnHit(hit);
        }
        else
        {
            SpawnDebug(hit.point);
        }

        return true;
    }
}