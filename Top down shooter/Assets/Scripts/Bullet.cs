using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
 {

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        var Player = hit.GetComponent<PlayerController>();
        if (health != null && Player != null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);
    }


}
