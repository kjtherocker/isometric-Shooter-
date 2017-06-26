using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
 {
    #region Variables
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    public LayerMask targetMask;

    public LayerMask obstacleMask;
    [HideInInspector]
    public List<Transform> visibletargets = new List<Transform>();


    #endregion

    #region Unity Methods

     void Start()
    {
        StartCoroutine("FindTargetsWithDelay",.2f);
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibletargets();
        }
    }

    IEnumerator Move(Vector3 destination, float speed)
    {
            while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

    }

    void FindVisibletargets()
    {
        visibletargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    // This is what we do if we do see a target we are looking for
                    visibletargets.Add(target);
                }
            }
        }
    }
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

	#endregion
}
