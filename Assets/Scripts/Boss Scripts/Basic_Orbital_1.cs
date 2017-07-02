using UnityEngine;
using System.Collections;

public class Basic_Orbital_1 : MonoBehaviour
{

    Vector3 ParentObjPos;
    TheFirstGuardian CenterPiece;
    
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
    }
	
	// Update is called once per frame
	void Update ()
    {
        ParentObjPos = transform.parent.position;

        if(m_State == OrbitalState.s_Extend)
        {
            m_Dir = new Vector3(transform.position.x - ParentObjPos.x, 0, transform.position.z - ParentObjPos.z).normalized;
            transform.Translate(m_Dir * Time.deltaTime);
        }
        

    }
}
