using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBullet : BaseEnemy
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private float _playerDistance;
    [SerializeField] private Vector3 _playerPos;
    [SerializeField] Rigidbody rb;

    [SerializeField] private float _speed;
    [SerializeField] private GameObject explosionPrefab;

    public float radius = 0.5f;

    protected override void Start()
    {
        base.Start();
        if(_player == null)
        {
            _player = FindObjectOfType<PlayerController>().transform;
        }

        _playerPos = _player.transform.position;

        Vector3 direction = _playerPos - (transform.position + (Vector3.up*0.2f));

        rb.velocity = direction.normalized * _speed;
    }

    protected override void Update()
    {
        Billboard();
    }

    protected override void OnDrawGizmos()
    {
        if(_playerPos != null)
            Gizmos.DrawLine(transform.position, _playerPos);

        Gizmos.DrawWireSphere(transform.position + (Vector3.up * 0.2f), radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Terrain"))
        {
            if(other.CompareTag("Player"))
            {
                _player.GetComponent<PlayerController>().OnHit(_baseDamage);
            }
            else if(Vector3.Distance(transform.position + (Vector3.up*0.2f), _player.position) < radius)
            {
                _player.GetComponent<PlayerController>().OnHit(_baseDamage);
            }

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
