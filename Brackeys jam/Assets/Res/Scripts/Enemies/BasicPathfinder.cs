using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicPathfinder : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    public Transform _player;

    [SerializeField] private int _health;

    [SerializeField] private float _shotSpeed;
    [SerializeField] private float _range;
    [SerializeField] private float _inaccuarcy;
    private float _shotCooldown;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        _navMeshAgent.SetDestination(_player.position);

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