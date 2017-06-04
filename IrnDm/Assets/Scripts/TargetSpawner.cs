using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

    public float SpawnSpeed;

    public GameObject Target;

    private bool isSpawning = false;
    private bool readyNow = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (isSpawning && readyNow)
        {
            StartCoroutine(MakeObject());
        }
    }

    IEnumerator MakeObject()
    {
        readyNow = false;
        Instantiate(Target, NextSpawnPosition());
        yield return new WaitForSeconds(SpawnSpeed);
        readyNow = true;
    }

    Transform NextSpawnPosition() {
        //Add logic for random spawn
        return gameObject.transform;
    }

    public void StartSpawning() {
        isSpawning = true;
    }

    public void StopSpawning() {
        isSpawning = false;
    }
}
