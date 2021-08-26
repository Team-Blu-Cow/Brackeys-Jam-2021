using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected int _health;

    [SerializeField] protected float _shotSpeed;
    [SerializeField] protected float _range;
    [SerializeField] protected float _inaccuarcy;
    protected float _shotCooldown;

    public Transform _player;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Vector3.Distance(_player.position, transform.position) < _range)
        {
            if (_shotCooldown < _shotSpeed)
            {
                _shotCooldown += Time.deltaTime;
            }
            else
            {
                _shotCooldown = 0;
                float xInac = Random.Range(0, _inaccuarcy);
                float yInac = Random.Range(0, _inaccuarcy);
                float zInac = Random.Range(0, _inaccuarcy);
                float rayL = _range;
                Ray ray = new Ray(transform.position, transform.forward + new Vector3(xInac, yInac, zInac));
                if (Physics.Raycast(ray, out RaycastHit hit, _range))
                {
                    if (hit.transform.name == "Capsule")
                    {
                        Debug.Log("Player Hit");
                        rayL = Vector3.Distance(hit.point, transform.position);
                    }
                    else
                    {
                        Debug.Log("Player Missed");
                    }

                    Debug.DrawRay(transform.position, (transform.forward + new Vector3(xInac, yInac, zInac)) * rayL, Color.green, _range);
                }
            }
        }
    }

    public void Hit()
    {
        _health--;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}