using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerTurret : MonoBehaviour
{
    #region Variables
    public float MoveSpeed;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public PlayerController Player;
    public LayerMask targetMask;
    #endregion

    #region Unity Methods
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();

        InvokeRepeating("Fire", 2.0f, 0.7f);
    }


    void FixedUpdate()
    {
  
    }

    void Update()
    {

        
        if (Player != null)
        {
            var Rotation = Player.transform.position;
    
            transform.LookAt(Rotation);
            transform.Rotate(0, 90, 0);

        }
        else
        {

        }
    }

    void Fire()
    {
            
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation
                );

         
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 3;

        
            Destroy(bullet, 10.0f);
            
        
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

