using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnParticlesOnStop : MonoBehaviour
{
    private ParticleSystem ps;
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

	void Update ()
    {
		if(ps.isStopped)
        {
            Destroy(gameObject);
        }
	}
}
