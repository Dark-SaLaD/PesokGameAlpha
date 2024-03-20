using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitScript : MonoBehaviour
{
    public int healAmount;

    private void OnTriggerEnter(Collider other) {
        //heal player
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
