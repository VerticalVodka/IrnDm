using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    public GameObject particleSystemPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (particleSystemPrefab != null)
        {
            Debug.Log(gameObject.transform.position.y);
            Debug.Log(particleSystemPrefab);
            GameObject particleSystem = Instantiate(particleSystemPrefab, gameObject.transform.position,Quaternion.identity);
            Destroy(particleSystem,5);
        }
        Destroy(gameObject);
    }
}
