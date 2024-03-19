using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBall : MonoBehaviour
{
    public int sandSpeed;
    public int sandLifeTime;
    public int damage;

    private void Start() {
        //sandball destroy over time
        Invoke("DestroySandball", sandLifeTime);
    }

    void FixedUpdate() {
        //sandball move
        transform.position += transform.forward * sandSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        //damamge
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null) {
            enemyHealth.DealDamage(damage);
        }

        //sandball destroy on collision
        DestroySandball();
    }

    private void DestroySandball() {
        //sandball destroy
        Destroy(gameObject);
    }
}
