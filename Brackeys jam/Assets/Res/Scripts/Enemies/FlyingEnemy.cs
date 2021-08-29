using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemy : BaseEnemy
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private float _playerDistance;
    [SerializeField] private float _shootSpeed = 1f;
    [SerializeField] private GameObject _bulletPrefab;


    private float _shootTimer = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void Update()
    {
        //base.Update();
        Billboard();

        if (Vector3.Distance(_player.position, transform.position) > _playerDistance &&

        Vector3.Distance(_player.position, transform.position) < _aggroRange )

            _navMeshAgent.SetDestination(_player.position);
        else
            _navMeshAgent.SetDestination(transform.position);

        _shootTimer += Time.deltaTime;

        if(_shootTimer >= _shootSpeed)
        {
            _shootTimer = 0;
            // shoot the player
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    protected override void OnDrawGizmos()
    {
        if (showGizmo)
        {
            base.OnDrawGizmos();
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _playerDistance);
        }
    }
}