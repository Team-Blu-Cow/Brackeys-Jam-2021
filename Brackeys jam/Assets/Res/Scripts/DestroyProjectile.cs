using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    [HideInInspector] public ProjectileShooting m_shooing;
    private int m_bounceAmount;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(WaitDestroy(m_shooing.m_modifiers.m_range / 10));
    }

    private IEnumerator WaitDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Capsule") //#TODO #jack change to player
            return;

        m_shooing.OnHit(collision);

        if (m_bounceAmount < m_shooing.m_modifiers.m_bounces)
        {
            m_bounceAmount++;
            return;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Capsule") //#TODO #jack change to player
            return;

        m_shooing.OnHit(other.transform, transform.position);

        if (m_bounceAmount < m_shooing.m_modifiers.m_bounces)
        {
            m_bounceAmount++;
            return;
        }

        Destroy(gameObject);
    }
}