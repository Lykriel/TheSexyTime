using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    public GameObject WinCanvas;
    protected enum MORTALITY_STATE
    {
        SpankMeDaddy,
        NutsackOfSteel,
        FuckFarOff

    };

    
    public int m_MoveSpeed;
    public GameObject player;


    protected int m_Health;
    protected MORTALITY_STATE m_Mortality;



    // Use this for initialization
    void Start ()
    {
        m_Mortality = MORTALITY_STATE.NutsackOfSteel;
       
        m_Health = 1;
        m_MoveSpeed = 0;
       
        
	}

    public void TakeDamage(int damage)
    {
        if (m_Mortality == MORTALITY_STATE.SpankMeDaddy)
        {
            m_Health -= damage;
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
