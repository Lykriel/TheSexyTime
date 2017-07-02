using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
   
    protected enum MORTALITY_STATE
    {
        SpankMeDaddy,
        NutsackOfSteel,
        FuckFarOff

    };

    private int m_Health;
    public int m_MoveSpeed;
    public GameObject player;
   
   
   
    protected MORTALITY_STATE m_Mortality;



    // Use this for initialization
    void Start ()
    {
        m_Mortality = MORTALITY_STATE.NutsackOfSteel;
       
        m_Health = 1;
        m_MoveSpeed = 10;
       
        
	}

    public void TakeDamage(int damage)
    {
        m_Health -= damage;
        if(m_Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
