using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;

    public PlayerController player;

    public float viewAngle;

    private bool _isPlayerNoticed;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    void Update()
    {
        var direction = player.transform.position - transform.position;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
                else
                {
                    _isPlayerNoticed = false;
                }
            }
            else
            {
                _isPlayerNoticed = false;
            }
        }
        else
        {
            _isPlayerNoticed = false;
        }
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }

        if (!_isPlayerNoticed)
        {
           if (_navMeshAgent.remainingDistance == 0)
           {
                _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
           }
        }
        
    }
}
