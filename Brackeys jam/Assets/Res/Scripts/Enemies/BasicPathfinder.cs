using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicPathfinder : BaseEnemy
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField] private float _playerDistance;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Vector3.Distance(_player.position, transform.position) > _playerDistance)
            _navMeshAgent.SetDestination(_player.position);
        else
            _navMeshAgent.SetDestination(transform.position);

        base.Update();
    }
}