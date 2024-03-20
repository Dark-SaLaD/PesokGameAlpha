using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandGrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;

    void Update() {
        //cast sandgrenade
        if (Input.GetMouseButtonDown(1)) {
            var grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            grenade.GetComponent<Rigidbody>().AddForce(transform.forward * 600);
        }
    }
}
