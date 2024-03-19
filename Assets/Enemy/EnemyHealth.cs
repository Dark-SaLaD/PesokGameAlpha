using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int value;

    public void DealDamage(int damage) {
        //damage and destroy enemy
        value -= damage;
        if (value <= 0) {
            Destroy(gameObject);
        }
    }
}
