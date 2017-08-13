using UnityEngine;
using System.Collections;

public class TheSecondGuardian_Sheilds : HitBox
{
    TheSecondGuardian m_Parent;
	// Use this for initialization
	void Start ()
    {
        m_Mortality = MORTALITY_STATE.SpankMeDaddy;
        m_MoveSpeed = 0;
        m_Parent = GetComponentInParent<TheSecondGuardian>();
        m_Health = 1;
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Renderer>().material.color = new Color(0, 0, 1);
        if (m_Health <= 0)
        {
            m_Parent.WallBreak();
        }
	}

    
}
