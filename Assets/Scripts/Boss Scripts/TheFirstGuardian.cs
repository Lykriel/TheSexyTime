using UnityEngine;
using System.Collections;

public class TheFirstGuardian : HitBox
{

    protected enum AI_STATE
    {

        s_Aiming,
        s_Patrol,
        s_Rest,
        s_Stunned,
        s_TripleAttack

    };
   

    int m_AttackCount;
    int m_SpinFactor;
    protected AI_STATE m_State;

    //state stuff
    float m_StateTimer;
    float m_StateLifeSpan;
    Vector3 m_TargetLocation;
    bool m_IsRandomed;
    bool m_IsAim;


    // Use this for initialization
    void Start()
    {
        m_Mortality = MORTALITY_STATE.NutsackOfSteel;
        m_State = AI_STATE.s_Patrol;
        m_Health = 1;
        m_MoveSpeed = 10;
        m_IsRandomed = false;
        m_IsAim = false;
        m_SpinFactor = 75;
        m_AttackCount = 0;

    }


    // Update is called once per frame
    void Update()
    {
       
        //change color depending on mortality
        if (m_Mortality == MORTALITY_STATE.FuckFarOff)
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            m_SpinFactor = 500;
        }
        else
        {
            m_SpinFactor = 75;
        }

        if (m_Mortality == MORTALITY_STATE.SpankMeDaddy)
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 1);
        }

        if (m_Mortality == MORTALITY_STATE.NutsackOfSteel)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }

        //state changing and AI
        switch (m_State)
        {
            //patrol 3-8 seconds(immortal)
            case AI_STATE.s_Patrol:
                m_Mortality = MORTALITY_STATE.NutsackOfSteel;
                if (!m_IsRandomed)
                {
                    m_StateLifeSpan = Random.Range(8, 12);
                    m_IsRandomed = true;
                }
                if (!m_IsAim)
                {
                    m_TargetLocation = new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));
                    m_IsAim = true;
                }
                if (m_IsAim)
                {
                    Vector3 move = (m_TargetLocation - transform.position).normalized;
                    move.y = 0;
                    transform.Translate(move * Time.deltaTime * 5, Space.World);
                    if (Vector3.Distance(m_TargetLocation, transform.position) <= 1.0f)
                    {
                        m_IsAim = false;
                    }

                }
                m_StateTimer += Time.deltaTime;
                if (m_StateTimer >= m_StateLifeSpan)
                {
                    m_State = AI_STATE.s_Aiming;
                    m_StateTimer = 0.0f;
                    m_IsAim = false;
                    m_IsRandomed = false;
                }


                break;
            //aim for 1 second and wait for 0.5 seconds(vulnerable)
            case AI_STATE.s_Aiming:
                if (!m_IsAim)
                {
                    m_Mortality = MORTALITY_STATE.SpankMeDaddy;
                    m_TargetLocation = player.transform.position;
                    m_StateTimer += Time.deltaTime;
                    if (m_StateTimer >= 1.0f)
                    {
                        m_StateTimer = 0.0f;
                        m_IsAim = true;
                    }


                }
                if (m_IsAim)
                {
                    m_Mortality = MORTALITY_STATE.FuckFarOff;
                    m_StateTimer += Time.deltaTime;
                    if (m_StateTimer >= 0.5f)
                    {
                        m_StateTimer = 0.0f;
                        m_IsAim = false;
                        m_State = AI_STATE.s_TripleAttack;
                        m_AttackCount += 1;
                    }
                }
                break;

            //dash forward (attack )
            case AI_STATE.s_TripleAttack:
                Vector3 moveVec = (m_TargetLocation - transform.position).normalized;
                moveVec.y = 0;
                transform.Translate(moveVec * Time.deltaTime * 20,Space.World);
                if (Vector3.Distance(m_TargetLocation, transform.position) <= 1.0f)
                {
                    if (m_AttackCount < 4)
                    {
                        m_State = AI_STATE.s_Aiming;
                    }
                    else
                    {
                        m_AttackCount = 0;
                        m_State = AI_STATE.s_Patrol;
                    }

                }
                break;

        }
        transform.Rotate(transform.up * Time.deltaTime * m_SpinFactor, Space.World);
    }

}
