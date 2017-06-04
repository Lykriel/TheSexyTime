using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour
{
    private int m_Health;
    public int m_MoveSpeed;
    public float m_AttackDelayTime;
    private Player player; 
    float m_AttackTimer;
    Vector3 m_TargetLocation;

    enum AI_STATE
    {

    };

	// Use this for initialization
	void Start ()
    {
        GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        m_Health = 5;
        m_MoveSpeed = 10;
        m_AttackDelayTime = 3;//3 s between
        player = GetComponent<Player>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
