using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<GameController>().DecScore();
        }
        if (collision.collider.tag == "Projectile")
        {
            FindObjectOfType<GameController>().IncScore();
        }
            Destroy(gameObject);
    }
}
