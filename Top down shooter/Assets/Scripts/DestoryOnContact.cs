using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnContact : MonoBehaviour
 {
    #region Variables
    #endregion

    #region Unity Methods
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
        Destroy(gameObject);
    }
    #endregion
}
