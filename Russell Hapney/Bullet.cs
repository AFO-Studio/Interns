using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        var hit = collision.gameObject;
        var playerHealth = hit.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(10);
        }
    }
}
