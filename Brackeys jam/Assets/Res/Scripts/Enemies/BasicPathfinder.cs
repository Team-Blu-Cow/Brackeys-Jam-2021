using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicPathfinder : BaseEnemy
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private float _playerDistance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();
        YBillboard();

        if (Vector3.Distance(_player.position, transform.position) > _playerDistance &&
        Vector3.Distance(_player.position, transform.position) < _aggroRange)
            _navMeshAgent.SetDestination(_player.position);
        else
            _navMeshAgent.SetDestination(transform.position);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _playerDistance);
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