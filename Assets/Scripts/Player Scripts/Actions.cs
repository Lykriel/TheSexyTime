using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actions : MonoBehaviour {


    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    private ParticleSystem Slash;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    HitBox m_hitBox;

    [HideInInspector]
    public List<GameObject> visibleTargets = new List<GameObject>();

    private void Start()
    {
        Slash = transform.FindChild("Slash").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindTargets();
            Slash.Emit(1);
            for (int i = 0; i < visibleTargets.Count; i++)
            {
                if (visibleTargets[i].GetComponent<HitBox>())
                {
                    //codes here
                    visibleTargets[i].GetComponent<HitBox>().TakeDamage(1);
                }
            }
        }
    }

    void FindTargets()
    {
        visibleTargets.Clear();
        Collider[] targetInRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetInRadius.Length; i++)
        {
            GameObject target = targetInRadius[i].gameObject;
            Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
            if (Vector3.Angle (transform.forward,dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.transform.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget,obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
            
        }
    }

    public Vector3 DirFromAngle(float angleInDegree, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegree += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }

}
