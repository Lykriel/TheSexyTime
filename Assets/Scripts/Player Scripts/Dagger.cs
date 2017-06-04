using UnityEngine;
using System.Collections;

public class Dagger : MonoBehaviour {

    public GameObject dagger;
    public float cooldown;

	// Update is called once per frame
	void Update () {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Check() == null)
            {
                if (cooldown <= 0)
                {
                    CreateDagger();
                }
            }
            else
            {
                Teleport(Check());
            }
        }
           
	}

    private void CreateDagger()
    {
        GameObject projectile = Instantiate(dagger);
        projectile.transform.position += transform.position;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 10;
        Debug.Log(transform.forward * 10);
        Physics.IgnoreLayerCollision(9,10);
        Destroy(projectile, 3.0f);
        cooldown = 6.0f;
        
    }
    private void Teleport(GameObject projectile)
    {
        transform.position = projectile.transform.position;
        Destroy(projectile);
        cooldown = 3.0f;
    }

    private GameObject Check()
    {
        return GameObject.Find("Dagger(Clone)");
    }
}
