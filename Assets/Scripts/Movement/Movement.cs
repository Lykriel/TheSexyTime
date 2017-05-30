using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    [SerializeField]
    float movespeed = 5f;
    bool m_isAttacking = false;
    Vector3 forward, right;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            
            Move();
            if(AttackCheck())
            {
                //attack in current facing direction
            }
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * movespeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement =  forward * movespeed * Time.deltaTime * Input.GetAxis("Vertical");
        

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        //if(m_isAttacking)
        //transform.forward = heading;

        transform.position += rightMovement;
        transform.position += upMovement;
    }

    bool AttackCheck()
    {
        //face 45 deg clockwise
        if (Input.GetKey("up") && Input.GetKey("right"))
        {
            transform.forward = new Vector3(1, 0, 1);
            return true;
        }

        //face 135 deg clockwise
        if (Input.GetKey("down") && Input.GetKey("right"))
        {
            transform.forward = new Vector3(1, 0, -1);
            return true;
        }

        //face 45 deg counter-clockwise
        if (Input.GetKey("up") && Input.GetKey("left"))
        {
            transform.forward = new Vector3(-1, 0, 1);
            return true;
        }

        //face 135 deg counter-clockwise
        if (Input.GetKey("down") && Input.GetKey("left"))
        {
            transform.forward = new Vector3(-1, 0, -1);
            return true;
        }
        //face up
        if (Input.GetKey("up"))
        {
            transform.forward = new Vector3(0,0,1);
            return true;
        }

        if (Input.GetKey("down"))
        {
            transform.forward = new Vector3(0, 0, -1);
            return true;
        }
        if (Input.GetKey("left"))
        {
            transform.forward = new Vector3(-1, 0, 0);
            return true;
        }
        if (Input.GetKeyDown("right"))
        {
            transform.forward = new Vector3(1, 0, 0);
            return true;
        }

        return false;

    }
}
