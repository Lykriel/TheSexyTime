using UnityEngine;
using System.Collections;

public class TheSecondGuardian : HitBox
{
    public enum AI_STATE
    {
        s_Delay,
        s_Move,
    };
    enum AI_Direction
    {
        NONE,
        X_Positive,
        X_Negative,
        Z_Positive,
        Z_Negative,
    }
    float m_MoveDelayTimer;
    bool m_TimerON;
    float m_rotationAmount;
    public int m_rotateSpeed;
    int m_WallNum;
    AI_STATE m_state;
    AI_Direction m_Direction;
    float m_StartRotation;
	// Use this for initialization
	void Start ()
    {
        m_MoveSpeed = 7;
        m_rotateSpeed = 20;
        m_MoveDelayTimer = 0.0f;
        m_TimerON = false;
        m_Mortality = MORTALITY_STATE.NutsackOfSteel;
        m_state = AI_STATE.s_Delay;
        m_rotationAmount = 90.0f;
        m_Direction = AI_Direction.NONE;
        m_StartRotation = 0f;
        m_WallNum = 6;
        
	}

    
	
    public void WallBreak()
    {
        m_WallNum -= 1;
        if (m_WallNum <= 0)
        {
            m_Mortality = MORTALITY_STATE.SpankMeDaddy;
        }

    }
	// Update is called once per frame
	void Update ()
    {
        if (m_Mortality == MORTALITY_STATE.SpankMeDaddy)
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, 1);
        }

        if (m_Mortality == MORTALITY_STATE.NutsackOfSteel)
        {
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
        if (transform.position.y != 2.5)
        {
            transform.position.Set(transform.position.x, 2.5f, transform.position.z);
        }
        switch (m_state)
        {
            case AI_STATE.s_Delay:
                Debug.Log("delay");
                //start Delay timer
                m_MoveDelayTimer += Time.deltaTime;
                if(m_MoveDelayTimer >= 1f)
                {
                    m_MoveDelayTimer = 0f;
                    m_state = AI_STATE.s_Move;
                    //figure out which direction to turn
                    Vector3 VectorBetw = transform.position - player.transform.position;

                    //player is closer to boss on x axis
                    if(Mathf.Abs(VectorBetw.x) < Mathf.Abs(VectorBetw.z))
                    {
                        //if closer on positive x axis
                        if(VectorBetw.x > 0)
                        {
                            m_Direction = AI_Direction.X_Positive;
                        }
                        else if(VectorBetw.x < 0 )
                        {
                            m_Direction = AI_Direction.X_Negative;
                        }
                        m_StartRotation = transform.rotation.z;
                    }

                    //player is closer to boss on z axis
                    else if (Mathf.Abs(VectorBetw.z) < Mathf.Abs(VectorBetw.x))
                    {
                        //if closer on positive z axis
                        if (VectorBetw.z > 0)
                        {
                            m_Direction = AI_Direction.Z_Positive;
                        }
                        else if (VectorBetw.z < 0)
                        {
                            m_Direction = AI_Direction.Z_Negative;
                        }
                    }
                    else
                    {
                        Debug.Log("fail");
                    }




                }

                break;

            case AI_STATE.s_Move:
                //if(transform.position.z > 22 || transform.position.z < -25 || transform.position.x <-27|| transform.position.x > 20 )
                //{
                //    m_rotationAmount = 90f;
                //    transform.eulerAngles = (new Vector3(0, 0, 0));
                //    m_state = AI_STATE.s_Delay;
                //    transform.Translate(0, 2, 0, Space.World);
                //}
                Debug.Log("MOVE");
                Debug.Log(m_Direction);
                float rotation = m_rotateSpeed * Time.deltaTime;
                //float movement = m_MoveSpeed * Time.deltaTime;
                if(m_Direction == AI_Direction.NONE)
                {
                    m_state = AI_STATE.s_Delay;
                    break;
                }
                if (m_Direction == AI_Direction.X_Negative)
                {
                    if (m_rotationAmount > rotation)
                    {
                        m_rotationAmount -= rotation;
                        transform.Rotate(new Vector3(-m_rotationAmount, 0, 0));
                        Vector3 moveVec = (player.transform.position - transform.position).normalized;
                        moveVec.y = 0;
                        transform.Translate(moveVec * Time.deltaTime * m_MoveSpeed, Space.World);
                    }
                    else
                    {
                        m_rotationAmount = 90f;
                        transform.eulerAngles = (new Vector3(0, 0, 0));
                        m_state = AI_STATE.s_Delay;
                    }
                }

                if (m_Direction == AI_Direction.X_Positive)
                {
                    if (m_rotationAmount > rotation)
                    {
                        
                        m_rotationAmount -= rotation;
                        transform.Rotate(new Vector3(m_rotationAmount, 0, 0));
                        //transform.Translate(0, 0, movement, Space.World);
                        Vector3 moveVec = (player.transform.position - transform.position).normalized;
                        moveVec.y = 0;
                        transform.Translate(moveVec * Time.deltaTime * m_MoveSpeed, Space.World);
                    }
                    else
                    {
                        m_rotationAmount = 90f;
                        transform.eulerAngles = (new Vector3(0, 0, 0));
                        m_state = AI_STATE.s_Delay;
                    }
                }


                if (m_Direction == AI_Direction.Z_Negative)
                {
                    if (m_rotationAmount > rotation)
                    {
                        
                        m_rotationAmount -= rotation;
                        transform.Rotate(new Vector3(0, 0, m_rotationAmount));
                        //transform.Translate(movement, 0, 0, Space.World);
                        Vector3 moveVec = (player.transform.position - transform.position).normalized;
                        moveVec.y = 0;
                        transform.Translate(moveVec * Time.deltaTime * m_MoveSpeed, Space.World);
                    }
                    else
                    {
                        m_rotationAmount = 90f;
                        transform.eulerAngles = (new Vector3(0, 0, 0));
                        m_state = AI_STATE.s_Delay;
                    }
                }

                if (m_Direction == AI_Direction.Z_Positive)
                {
                    if (m_rotationAmount > rotation)
                    {
                       
                        m_rotationAmount -= rotation;
                        transform.Rotate(new Vector3(0, 0, -m_rotationAmount));
                        //transform.Translate(-movement, 0, 0, Space.World);
                        Vector3 moveVec = (player.transform.position - transform.position).normalized;
                        moveVec.y = 0;
                        transform.Translate(moveVec * Time.deltaTime * m_MoveSpeed, Space.World);
                    }
                    else
                    {
                        m_rotationAmount = 90f;
                        transform.eulerAngles = (new Vector3(0, 0, 0));
                        m_state = AI_STATE.s_Delay;
                    }
                }

                
                break;

        }
	}
}
