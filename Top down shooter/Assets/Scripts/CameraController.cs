using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }


    void LateUpdate()
    {
        offset = player.transform.position - transform.position;
        if (player != null)
        {
            Vector3 movement = new Vector3(offset.x * Time.deltaTime * 4, 100 - transform.position.y, offset.z * Time.deltaTime * 4);
            
            transform.position += movement;
        }
    }
}

