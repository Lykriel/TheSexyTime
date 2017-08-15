using UnityEngine;
using System.Collections;

public class Basic_Orbital_1 : MonoBehaviour
{

    Vector3 ParentObjPos;
    TheFirstGuardian CenterPiece;
    public GameObject thePlayer;
    enum OrbitalState
    {
        s_Protect,
        s_Extend,
        s_Retract,
    };

    OrbitalState m_State;
    Vector3 m_OrgPos;
    Vector3 m_Dir;
    float m_Timer;
	// Use this for initialization
	void Start ()
    {
        CenterPiece = GetComponentInParent<TheFirstGuardian>();
        m_State = OrbitalState.s_Extend;
        m_OrgPos = transform.position;
        m_Timer = 0.0f;
        thePlayer = GetComponent<GameObject>();
        
    }
    void OnCollisionEnter(Collision col)
    {
        //if(CenterPiece.GetState() == TheFirstGuardian.AI_STATE.s_TripleAttack)
        if (col.gameObject == thePlayer)
        {
            Player.Instance.GetHit();
                Debug.Log("hit");
        }
    }
    // Update is called once per frame
    void Update ()
    {

        ParentObjPos = transform.parent.position;
        if (CenterPiece.GetState() == TheFirstGuardian.AI_STATE.s_TripleAttack)
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }

        if(m_State == OrbitalState.s_Extend)
        {
            m_Timer += Time.deltaTime;
            m_Dir = new Vector3(transform.position.x - ParentObjPos.x, 0, transform.position.z - ParentObjPos.z).normalized;
            transform.Translate(m_Dir * Time.deltaTime * 2, Space.World);
            if(m_Timer >= 1.5f)
            {
                m_State = OrbitalState.s_Retract;
                m_Timer = 0.0f;
            }
        }
        if (m_State == OrbitalState.s_Retract)
        {
            m_Timer += Time.deltaTime;
            m_Dir = new Vector3(ParentObjPos.x - transform.position.x, 0, ParentObjPos.z - transform.position.z).normalized;
            transform.Translate(m_Dir * Time.deltaTime * 2, Space.World);
            if (m_Timer >= 1.5f)
            {
                m_State = OrbitalState.s_Extend;
                m_Timer = 0.0f;
            }
        }


    }
}
