using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float m_time;

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
        if (collision.transform.CompareTag("Enemy"))
            Debug.Log(collision.transform.name);

        if (collision.transform.name != "Capsule")
            Destroy(gameObject);
    }
}