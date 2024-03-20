using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGrenade : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision) {
        //timer of explosion
        Invoke("Explosion", 3);
    }

    private void Explosion() {
        //create explotion
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //delete grenade
        Destroy(gameObject);
    }
}
