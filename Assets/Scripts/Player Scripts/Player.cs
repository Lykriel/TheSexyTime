using UnityEngine;
using System.Collections;

public class Player : Singleton<Player>
{
    public GameObject DeathCanvas;
    public int m_Health = 1;

	// Use this for initialization
	void Start ()
    {
        DeathCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_Health <= 0)
        {
            DeathCanvas.SetActive(true);
        }
	}
}
