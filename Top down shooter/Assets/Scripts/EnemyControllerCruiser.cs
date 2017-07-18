using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerCruiser : MonoBehaviour
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

void Update()
{


    if (Player != null)
    {
        var Rotation = Player.transform.position;

        transform.LookAt(Rotation);
        transform.Rotate(0, 180, 0);

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

    #endregion

}

