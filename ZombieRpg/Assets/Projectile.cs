using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    PlayerAttack playerAttack;
    float destroyTime = 10;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update () {
        GetComponent<Rigidbody>().velocity = transform.forward * FindObjectOfType<PlayerAttack>().projSpeed;
	}

    private void OnTriggerEnter(Collider other)
    {
        //IF COLLIDING WITH A CHARACTER
        Health health = other.GetComponent<Health>();
        if (health)
        {
            if (!gameObject.CompareTag(other.tag))
            {
                health.TakeDamage(5);
            }
        }
        Destroy(gameObject);
    }
}
