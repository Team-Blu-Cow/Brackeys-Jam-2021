using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : BaseShooting
{
    [SerializeField]
    private GameObject m_bullet;

    public float m_bulletSpeed;

    public override bool Shoot()
    {
        if (!base.Shoot())
            return false;

        Transform camTransform = Camera.main.transform;

        GameObject bullet = Instantiate(m_bullet, camTransform.position + camTransform.forward, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().AddForce(camTransform.forward * m_bulletSpeed, ForceMode.Impulse);

        return true;
    }
    private void OnCollisionEnter(Collision collision)
    {
                Destroy(gameObject);

    }
    private void OntriggerEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}