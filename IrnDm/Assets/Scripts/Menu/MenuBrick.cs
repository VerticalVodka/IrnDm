using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBrick : MonoBehaviour {

    public float FloatingSpeed;
    public float Amplitude;
    public MenuItemType itemType;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, Amplitude * Mathf.Sin(Time.time * FloatingSpeed)));
	}
}
