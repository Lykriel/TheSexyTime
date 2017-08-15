using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actions : MonoBehaviour {


    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    private ParticleSystem Slash;
    private float cooldown;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    HitBox m_hitBox;

    [HideInInspector]
    public List<GameObject> visibleTargets = new List<GameObject>();

    private void Awake()
    {
        Slash = transform.FindChild("Slash").GetComponent<ParticleSystem>();
        Slash.Stop();
    }

    private void Start()
    {
        cooldown = 1.0f;
    }

    private void Update()
    {
        if (gameObject.GetComponent<Player>().m_Health > 0)
        {
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (cooldown <= 0)
                {
                    FindTargets();
                    Slash.Emit(1);
                    cooldown = 0.5f;
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
