using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBullet : MonoBehaviour
{
    public BaseShooting.HitType m_hitType;
    public BaseShooting m_shooting;
    public bool m_hit = false;
    public List<Vector3> m_hitPos;
    public float m_range;

    public void Setup()
    {
        //LineRenderer line = Instantiate(Resources.Load<GameObject>("Line"), transform).GetComponent<LineRenderer>();

        //line.positionCount = m_hitPos.Count;
        //line.SetPositions(m_hitPos.ToArray());

        float sphereSize = 0.2f;

        if (m_hitType == BaseShooting.HitType.Explosive)
            sphereSize = m_shooting.m_modifiers.m_explosiveRadius;

        // get the shorter distance and draw a sphere
        if (m_hit || m_shooting is ProjectileShooting)
        {
            //GameObject test = Instantiate(Resources.Load<GameObject>("Sphere"), m_hitPos[m_hitPos.Count - 1], Quaternion.identity, transform);
            //test.transform.localScale = Vector3.one * sphereSize;
        }
    }
}