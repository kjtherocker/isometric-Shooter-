using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
 {
    #region Variables
    private Rigidbody EnemyRb;
    public float MoveSpeed;

  
    public PlayerController Player;
	#endregion 

	#region Unity Methods
	void Start()
	{
        EnemyRb = GetComponent<Rigidbody>();
        Player = FindObjectOfType<PlayerController>();

    }

     void FixedUpdate()
    {
        EnemyRb.velocity = (transform.forward * MoveSpeed);
    }



    void Update()
	{
        if (Player != null)
        {
            transform.LookAt(Player.transform.position);
          
        }
        else
        {

        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
        else if (health == null)
        {
            Player = null;
        }
        Destroy(gameObject);
    }
    #endregion
}
