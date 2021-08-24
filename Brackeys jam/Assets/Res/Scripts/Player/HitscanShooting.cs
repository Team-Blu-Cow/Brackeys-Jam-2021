using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanShooting : BaseShooting
{
    [HideInInspector]
    public Vector3 spread;

    public List<Vector3> points = new List<Vector3>();

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;

        // Random spread of the bullet
        spread = new Vector3(Random.Range(-m_modifiers.m_spread, m_modifiers.m_spread), Random.Range(-m_modifiers.m_spread, m_modifiers.m_spread), 0);

        Transform camTrasform = Camera.main.transform;

        // Check what the bullet hits if anything
        points.Clear();
        points.Add(camTrasform.position);

        if (!DrawReflectionPattern(camTrasform.position, camTrasform.forward + spread, m_modifiers.m_bounces + 1, m_modifiers.m_range))
        {
            SpawnDebug(points[0], false);
        }

        return true;
    }

    private bool DrawReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining, float range)
    {
        if (reflectionsRemaining == 0)
        {
            return false;
        }
        Vector3 startingPos = position;

        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            if (hit.transform.CompareTag("Enemy"))
            {
                points.Add(position);
                OnHit(hit);
                return true;
            }
        }
        else
        {
            position += direction * range;
        }

        points.Add(position);

        return DrawReflectionPattern(position, direction, reflectionsRemaining - 1, range - Vector3.Distance(startingPos, position));
    }
}