using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    private NavMeshAgent _navMeshAgent;

    public PlayerController player;
    private float viewAngle = 90;
    private bool _isPlayerNoticed;

    public float damage;
    private PlayerHealth _playerHealth;

    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update() {
        //raycast
        var direcrion = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward + Vector3.up, direcrion) <= viewAngle) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direcrion, out hit)) {
                if (hit.collider.gameObject == player.gameObject) {
                    _isPlayerNoticed = true;
                }
            }
        }

        //attack
        if (_isPlayerNoticed && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) {
            _playerHealth.DealDamage(damage * Time.deltaTime);
        }

        //chase
        if (_isPlayerNoticed) {
            _navMeshAgent.destination = player.transform.position;
        }

        //patrol
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isPlayerNoticed) {
            _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
        }
    }
}
