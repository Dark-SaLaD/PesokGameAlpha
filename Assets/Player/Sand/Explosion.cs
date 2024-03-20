using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 20;

    void Start() {
        //scale of explosion = 0
        transform.localScale = Vector3.zero;
    }

    void Update() {
        //make explosion bigger
        transform.localScale += Vector3.one * Time.deltaTime * 20;
        //and destroy it
        if (transform.localScale.x > 10) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //damage player
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.DealDamage(damage);
        }

        //damage enemy
        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null) {
            enemyHealth.DealDamage(damage);
        }
    }
}
