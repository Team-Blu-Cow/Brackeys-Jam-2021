using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float m_time;
    [HideInInspector] public int m_bounces;
    private int m_bounceAmount;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(WaitDestroy(m_time));
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

        if (collision.transform.CompareTag("Enemy"))
            Debug.Log(collision.transform.name);

        if (m_bounceAmount < m_bounces)
        {
            m_bounceAmount++;
            return;
        }

        Destroy(gameObject);
    }
}